using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.DataInterface
{
    public interface ILoanQualificationRule
    {

        String RuleName { get; }

        bool CheckLoanApprovalRule(LoanApplication application);


        
    }
}
