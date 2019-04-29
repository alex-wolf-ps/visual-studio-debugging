using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using LoanHelperDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Core.Services
{
    public class LoanProcessingService
    {
        private List<ILoanQualificationRule> _loanApprovalRules;
        private List<LoanRate> _loanRates;

        public LoanProcessingService(ILoanRateRepository loanRateRepository, List<ILoanQualificationRule> rules)
            : this(loanRateRepository.GetLoanRates(), rules.ToArray())
        {

        }

        public LoanProcessingService(List<LoanRate> rates, params ILoanQualificationRule[] rules)
        {
            _loanRates = rates;
            _loanApprovalRules = rules.ToList();
        }

        public LoanApplicationResult ProcessLoan(LoanApplication application)
        {
            // Check loan qualification rules
            var failingRules = _loanApprovalRules.FirstOrDefault(
                rule => rule.CheckLoanApprovalRule(application) == false);

            if (failingRules != null)
            {
                var result = LoanApplicationResult.CreateDeniedResult(application, failingRules);
                return result;
            }

            // Applicant qualifies for the loan, so figure out the interest rate we can offer and the monthly payment
            double interestRate = DetermineInterestRate(application);
            double monthlyPayment = CalculateLoanPayment(application.LoanAmount, application.Term.Years, interestRate);

            return LoanApplicationResult.CreateApprovedResult(application, interestRate, monthlyPayment);
        }


        private double DetermineInterestRate(LoanApplication application)
        {
            var creditScore = application.CreditScore;
            var rate = _loanRates.FirstOrDefault(r => 
                creditScore >= r.LowerCreditScore 
                && creditScore <= r.UpperCreditScore);

            // Premiere bankers discount
            if(application.ApplicantType.ToLower() == "premiere")
            {
                return rate.InterestRate + 0.1;
            }

            return rate.InterestRate;
        }


        internal double CalculateLoanPayment(double loanAmount, int termYears, double interestRate)
        {
            int totalPayments = termYears * 12;
            double monthlyInterest = interestRate / 12.0;
            double discountFactor = ((Math.Pow((1 + monthlyInterest),  totalPayments)) - 1.0) /
                (monthlyInterest * Math.Pow((1 + monthlyInterest), totalPayments));

            double monthlyPayment = Math.Round(loanAmount / discountFactor, 2);
            return monthlyPayment;
        }
    }
}
