using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using LoanHelperDemo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LoanCalculator.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private IWebHostEnvironment _env;

        private ILoanApplicationResultRepository _loanResultRepository;

        private ILoanRateRepository _loanRateRepository;

        public IndexModel(ILoanApplicationResultRepository loanResultRepository, ILoanRateRepository rateRepo, IWebHostEnvironment environment)
        {
            _env = environment;
            _loanResultRepository = loanResultRepository;
            _loanRateRepository = rateRepo;
        }

        public List<LoanRate> LoanRates { get; set; }

        public List<DisplayRate> MarketRates { get; set; }

        public List<LoanApplicationResult> LoanApplicationResults { get; set; }


        public void OnGet()
        {
            LoanApplicationResults = _loanResultRepository.GetLoanApplicationResults().Take(5).ToList();
            LoanRates = _loanRateRepository.GetLoanRates();

            try
            {
                // Loan Helper from Nuget Package to get market rates
                MarketRates = LoanHelper.GetMarketRates();
            }
            catch (Exception e)
            {
                // Todo: Log the error
            }
        }

        private List<MarketRate> GetSampleMarketRates()
        {
            return new List<MarketRate>()
            {
                new MarketRate()
                {
                    Label = "Auto",
                    MinRate = .02
                },
                new MarketRate()
                {
                    Label = "Home",
                    MinRate = .04
                },
                new MarketRate()
                {
                    Label = "Personal",
                    MinRate = .05
                },
                new MarketRate()
                {
                    Label = "Education",
                    MinRate = .06
                }
            };
        }
    }
}
