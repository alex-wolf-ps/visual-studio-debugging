using LoanCalculator.Core.DataInterface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LoanCalculator.RazorPages.Controllers
{
    public class LoanController : Controller
    {
        private ILoanApplicationResultRepository loanApplicationRepo;

        public LoanController(ILoanApplicationResultRepository repo)
        {
            this.loanApplicationRepo = repo;
        }

        [HttpGet("loans")]
        public IActionResult Index(int start, int length = 2)
        {
            var loanResults = this.loanApplicationRepo.GetLoanApplicationResults();
            var totalRecords = loanResults.Count;

            var filteredLoanResults = loanResults.Take(length).ToList();

            var response = new {
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords, data = filteredLoanResults
            };

            return Ok(response);
        }

        [HttpGet("loans/{id}")]
        public IActionResult Index(int id)
        {
            var loan = this.loanApplicationRepo.GetLoanApplicationResult(id);
            return View(loan);
        }
    }
}
