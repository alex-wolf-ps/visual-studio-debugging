using LoanCalculator.Core.DataInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class TermLengthApprovalRule : ILoanQualificationRule
    {
        public const String RULE_NAME = "Term Length";

        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(LoanApplication application)
        {
            if (application.LoanAmount < 50000)
            {
                // Smaller loans must have shorter terms
                return application.Term.Years <= 20;
            }
            else
            {
                // Large loans must have longer terms
                return application.Term.Years >= 15;
            }
        }


    }
}
