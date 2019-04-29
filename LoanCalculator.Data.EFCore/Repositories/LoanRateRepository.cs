using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoanCalculator.Data.EFCore
{


    public class LoanRateRepository : ILoanRateRepository
    {

        public LoanRateRepository(LoanCalculatorContext context)
        {
            _context = context;
        }


        private LoanCalculatorContext _context;



        public List<LoanRate> GetLoanRates()
        {
            return _context.LoanRates.ToList();
        }
    }


}
