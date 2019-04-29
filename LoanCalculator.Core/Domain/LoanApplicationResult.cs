using LoanCalculator.Core.DataInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanApplicationResult
    {

        public int ResultId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public int AnnualIncome { get; set; }

        public int CreditScore { get; set; }

        public double LoanAmount { get; set; }

        public int LoanTerm { get; set; }

        public Boolean Approved { get; set; }

        public String DenialReason { get; set; }

        public string ApplicantType { get; set; }

        public double? InterestRate { get; set; }

        public double? MonthlyPayment { get; set; }



        public static LoanApplicationResult CreateDeniedResult(
            LoanApplication application, ILoanQualificationRule failedRule)
        {
            return new LoanApplicationResult()
            {
                FirstName = application.FirstName,
                LastName = application.LastName,
                AnnualIncome = application.AnnualIncome,
                CreditScore = application.CreditScore,
                LoanAmount = application.LoanAmount,
                LoanTerm = application.Term.Years,
                Approved = false,
                DenialReason = failedRule.RuleName,
                ApplicantType = application.ApplicantType
            };
        }


        public static LoanApplicationResult CreateApprovedResult(LoanApplication application, double interestRate, double monthlyPayment)
        {
            return new LoanApplicationResult()
            {
                FirstName = application.FirstName,
                LastName = application.LastName,
                AnnualIncome = application.AnnualIncome,
                CreditScore = application.CreditScore,
                LoanAmount = application.LoanAmount,
                LoanTerm = application.Term.Years,
                Approved = true,
                InterestRate = interestRate,
                MonthlyPayment = monthlyPayment
            };
        }


    }
}
