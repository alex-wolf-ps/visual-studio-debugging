using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Data.EFCore
{
    public class LoanApplicationResultRepository : ILoanApplicationResultRepository
    {

        public LoanApplicationResultRepository(LoanCalculatorContext context)
        {
            _context = context;
        }


        private LoanCalculatorContext _context;

        public List<LoanApplicationResult> GetLoanApplicationResults()
        {
            return _context.LoanApplicationResults.ToList();
        }

        public void SaveLoanApplicationResult(LoanApplicationResult loanApplicationResult)
        {
            _context.LoanApplicationResults.Add(loanApplicationResult);
            _context.SaveChanges();
        }

        public LoanApplicationResult GetLoanApplicationResult(int id)
        {
            return _context.LoanApplicationResults.FirstOrDefault(r => r.ResultId == id);
        }
    }
}
