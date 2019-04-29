using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanType
    {
        public int LoanTypeId { get; set; }

        public string LoanTypeName { get; set; }

        public List<LoanRate> Rates { get; set; }
    }
}
