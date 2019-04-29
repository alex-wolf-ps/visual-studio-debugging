using LoanCalculator.Core.DataInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanSizeLoanApprovalRule : ILoanQualificationRule
    {


        public const String RULE_NAME = "Loan Size";

        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(LoanApplication application)
        {
            var loanAmount = application.LoanAmount;

            switch (loanAmount)
            {
                case double n when (n <= 10_000):
                    // We don't issue loans less than $50,000
                    return false;
                case double n when (n > 10_000 && n < 1_000_000):
                    // Loans from $50,000 to $1,000,000 are OK
                    return true;
                case double n when (n > 1_000_000 ):
                    // Do not issue loans over $1,000,000
                    return false;
                default:
                    return false;
            }
        }


    }
}
