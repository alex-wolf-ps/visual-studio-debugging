using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanCalculator.Core.Domain
{
    public class LoanApplication
    {
        [Required]
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public String LastName { get; set; }

        [Required]
        [DisplayName("Annual Income")]
        public int AnnualIncome { get; set; }

        [Required]
        [DisplayName("Years Employed")]
        public int YearsEmployed { get; set; }

        [Required]
        [DisplayName("Credit Score")]
        public int CreditScore { get; set; }

        [Required]
        [DisplayName("Loan Amount")]
        public double LoanAmount { get; set; }

        [Required]
        [DisplayName("Type of Applicant")]
        public string ApplicantType { get; set; }

        [DisplayName("Term")]
        public LoanTerm Term { get; set; }
    }
}
