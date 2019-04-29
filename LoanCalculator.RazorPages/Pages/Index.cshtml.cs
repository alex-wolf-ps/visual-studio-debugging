using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCheck;
using LoanCalculator.Core.DataInterface;
using LoanCalculator.Core.Domain;
using LoanHelperDemo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoanCalculator.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private IHostingEnvironment _env;

        private ILoanApplicationResultRepository _loanResultRepository;

        private ILoanRateRepository _loanRateRepository;

        public IndexModel(ILoanApplicationResultRepository loanResultRepository, ILoanRateRepository rateRepo, IHostingEnvironment environment)
        {
            _env = environment;
            _loanResultRepository = loanResultRepository;
            _loanRateRepository = rateRepo;
        }

        public List<LoanRate> LoanRates { get; set; }

        public List<MarketRate> MarketRates { get; set; }

        public List<LoanApplicationResult> LoanApplicationResults { get; set; }


        public void OnGet()
        {
            LoanApplicationResults = _loanResultRepository.GetLoanApplicationResults().Take(5).ToList();
            LoanRates = _loanRateRepository.GetLoanRates();


            if (_env.IsDevelopment())
            {
                MarketRates = this.GetSampleMarketRates();
            }
            else
            {
                // Todo: Simulate 3rd party library that only works in prod
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
