using LoanCalculator.Core.DataInterface;
using LoanHelperDemo;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace LoanCalculator.RazorPages.Controllers
{
    [Route("loans")]
    public class LoanController : Controller
    {
        private ILoanApplicationResultRepository loanApplicationRepo;

        public LoanController(ILoanApplicationResultRepository repo)
        {
            this.loanApplicationRepo = repo;
        }

        [HttpGet("")]
        public IActionResult Index(int start, int length = 2)
        {
            var loanResults = this.loanApplicationRepo.GetLoanApplicationResults();

            var totalRecords = loanResults.Count;

            var filteredLoanResults = loanResults.Skip(start).Take(length).ToList();

            foreach(var result in filteredLoanResults)
            {
                if(result.LoanTerm > 30)
                {
                    result.LoanTerm = result.LoanTerm / 12;
                }
            }
            
            var response = new {
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords, data = filteredLoanResults
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            var loan = this.loanApplicationRepo.GetLoanApplicationResult(id);
            return View(loan);
        }
    }
}
