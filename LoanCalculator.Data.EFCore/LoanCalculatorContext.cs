using LoanCalculator.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Data.EFCore
{
    public class LoanCalculatorContext : DbContext
    {

        public LoanCalculatorContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<LoanRate> LoanRates { get; set; }

        public DbSet<LoanApplicationResult> LoanApplicationResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this.ConfigureLoanTerm(modelBuilder);
            this.ConfigureLoanType(modelBuilder);
            this.ConfigureLoanRate(modelBuilder);
            this.ConfigureLoanApplicationResult(modelBuilder);
            this.SeedData(modelBuilder);
        }

        private void ConfigureLoanType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanType>()
                .ToTable("LoanTypes")
                .HasKey(lt => lt.LoanTypeId);
        }

        private void ConfigureLoanRate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanRate>()
                .ToTable("LoanRates")
                .HasKey(lt => lt.LoanRateId);
        }



        private void ConfigureLoanApplicationResult(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanApplicationResult>()
                .ToTable("LoanApplicationResults")
                .HasKey(r => r.ResultId);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanType>().HasData(
                new LoanType() { LoanTypeId = 1, LoanTypeName = "car" },
                new LoanType() { LoanTypeId = 2, LoanTypeName = "school" }
            );

            modelBuilder.Entity<LoanRate>().HasData(
                new LoanRate() { LoanTypeId = 2, LoanRateId = 1, LowerCreditScore = 300, UpperCreditScore = 499, InterestRate = 0.100 },
                new LoanRate() { LoanTypeId = 1, LoanRateId = 2, LowerCreditScore = 500, UpperCreditScore = 599, InterestRate = 0.085 },
                new LoanRate() { LoanTypeId = 1, LoanRateId = 3, LowerCreditScore = 600, UpperCreditScore = 699, InterestRate = 0.075 },
                new LoanRate() { LoanTypeId = 2, LoanRateId = 4, LowerCreditScore = 700, UpperCreditScore = 799, InterestRate = 0.0625 },
                new LoanRate() { LoanTypeId = 2, LoanRateId = 5, LowerCreditScore = 800, UpperCreditScore = 850, InterestRate = 0.05 }
            );

            modelBuilder.Entity<LoanApplicationResult>().HasData(
                new LoanApplicationResult() { ResultId = 1,  ApplicantType = "Standard", FirstName = "John", LastName = "Smith", AnnualIncome = 75_000, CreditScore = 790, Approved = true, InterestRate = 0.085, LoanAmount = 125_000, MonthlyPayment = 769.65, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 2,  ApplicantType = "Standard", FirstName = "Mary", LastName = "Jones", AnnualIncome = 60_000, CreditScore = 680, Approved = true, InterestRate = 0.075, LoanAmount = 135_000, MonthlyPayment = 934.94, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 4,  ApplicantType = "Standard", FirstName = "Sally", LastName = "Johnson", AnnualIncome = 125_000, CreditScore = 880, Approved = true, InterestRate = 0.05, LoanAmount = 250_000, MonthlyPayment = 1684.61, LoanTerm = 20 },
                new LoanApplicationResult() { ResultId = 5,  ApplicantType = "Standard", FirstName = "John", LastName = "Test", AnnualIncome = 75_000, CreditScore = 790, Approved = true, InterestRate = 0.075, LoanAmount = 125_000, MonthlyPayment = 769.65, LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 6,  ApplicantType = "Standard", FirstName = "Jeff", LastName = "Pral", AnnualIncome = 60_000, CreditScore = 680, Approved = true, InterestRate = 0.0625, LoanAmount = 135_000, MonthlyPayment = 934.94, LoanTerm = 10 },
                new LoanApplicationResult() { ResultId = 7,  ApplicantType = "Standard", FirstName = "Steve", LastName = "Sun", AnnualIncome = 100_000, CreditScore = 460, Approved = false, DenialReason = "Credit Score", LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 8,  ApplicantType = "Premiere", FirstName = "Alan", LastName = "Roll", AnnualIncome = 125_000, CreditScore = 880, Approved = true, InterestRate = 0.175, LoanAmount = 250_000, MonthlyPayment = 1684.61, LoanTerm = 20 },
                new LoanApplicationResult() { ResultId = 9,  ApplicantType = "Premiere", FirstName = "Bob", LastName = "Stevens", AnnualIncome = 75_000, CreditScore = 790, Approved = true, InterestRate = 0.15, LoanAmount = 25_000, MonthlyPayment = 769.65, LoanTerm = 10 },
                new LoanApplicationResult() { ResultId = 3,  ApplicantType = "Standard", FirstName = "Andy", LastName = "Anderson", AnnualIncome = 100_000, CreditScore = 460, Approved = false, DenialReason = "Credit Score", LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 10, ApplicantType = "Standard", FirstName = "Phil", LastName = "Tell", AnnualIncome = 60_000, CreditScore = 680, Approved = true, InterestRate = 0.075, LoanAmount = 135_000, MonthlyPayment = 934.94, LoanTerm = 20 },
                new LoanApplicationResult() { ResultId = 11, ApplicantType = "Standard", FirstName = "Joel", LastName = "Tess", AnnualIncome = 100_000, CreditScore = 406, Approved = false, DenialReason = "Credit Score", LoanTerm = 30 },
                new LoanApplicationResult() { ResultId = 12, ApplicantType = "Standard", FirstName = "Bob", LastName = "Test", AnnualIncome = 125_000, CreditScore = 880, Approved = true, InterestRate = 0.05, LoanAmount = 250_000, MonthlyPayment = 1684.61, LoanTerm = 20 }
            );
        }
    }
}
