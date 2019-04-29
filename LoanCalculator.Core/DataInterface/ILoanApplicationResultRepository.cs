using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.DataInterface
{
    public interface ILoanApplicationResultRepository
    {

        List<LoanApplicationResult> GetLoanApplicationResults();

        LoanApplicationResult GetLoanApplicationResult(int id);

        void SaveLoanApplicationResult(LoanApplicationResult loanApplicationResult);


    }
}
