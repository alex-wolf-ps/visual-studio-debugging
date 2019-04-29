using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanRate
    {


        public int LoanRateId { get; set; }

        public int LowerCreditScore { get; set; }

        public int UpperCreditScore { get; set; }


        public double InterestRate { get; set; }

        public int LoanTypeId { get; set; }

        public LoanType LoanType { get; set; }
    }
}
