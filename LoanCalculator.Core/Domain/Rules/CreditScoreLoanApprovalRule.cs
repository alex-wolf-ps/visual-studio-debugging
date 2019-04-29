using LoanCalculator.Core.DataInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class CreditScoreLoanApprovalRule : ILoanQualificationRule
    {

        public const String RULE_NAME = "Credit Score";

        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(LoanApplication application)
        {
            return application.CreditScore > 400;
        }
    }
}
