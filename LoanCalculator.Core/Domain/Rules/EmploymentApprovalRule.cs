using LoanCalculator.Core.DataInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class EmploymentApprovalRule : ILoanQualificationRule
    {
        public const String RULE_NAME = "Employment";

        public string RuleName { get => RULE_NAME; }

        public bool CheckLoanApprovalRule(LoanApplication application)
        {
            if (application.AnnualIncome <= application.LoanAmount)
            {
                return application.YearsEmployed > 2 && (application.AnnualIncome >= application.LoanAmount / 2);
            }

            return true;
        }


    }
}
