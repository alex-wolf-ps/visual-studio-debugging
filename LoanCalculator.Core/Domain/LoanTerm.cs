using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanTerm
    {

        public String Name { get => $"{Years} Years"; }

        public int Years { get; private set; }

        public int TotalPayments { get => Years * 12; }



        public static readonly LoanTerm YEARS_10 = new LoanTerm() { Years = 10 };

        public static readonly LoanTerm YEARS_15 = new LoanTerm() { Years = 15 };

        public static readonly LoanTerm YEARS_20 = new LoanTerm() { Years = 20 };

        public static readonly LoanTerm YEARS_30 = new LoanTerm() { Years = 30 };


        public static readonly ReadOnlyDictionary<int, LoanTerm> LoanTerms = new ReadOnlyDictionary<int, LoanTerm>(
            new Dictionary<int, LoanTerm>()
            {
                {  YEARS_10.Years, YEARS_10 },
                {  YEARS_15.Years, YEARS_15 },
                {  YEARS_20.Years, YEARS_20 },
                {  YEARS_30.Years, YEARS_30 }
            }

            );


        public static LoanTerm GetLoanTerm(int years)
        {
            if (LoanTerms.ContainsKey(years))
                return LoanTerms[years];

            return null;
        }


    }


}
