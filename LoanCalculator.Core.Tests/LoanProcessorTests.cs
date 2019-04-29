using LoanCalculator.Core.Domain;
using LoanCalculator.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace LoanCalculator.Core.Tests
{
    [TestClass]
    public class LoanProcessingServiceTests
    {

        #region Test Data

        public readonly List<LoanRate> Rates = new List<LoanRate>()
            {
                new LoanRate() { LowerCreditScore = 50, UpperCreditScore = 59, InterestRate = 0.085 },
                new LoanRate() { LowerCreditScore = 60, UpperCreditScore = 69, InterestRate = 0.075 },
                new LoanRate() { LowerCreditScore = 70, UpperCreditScore = 79, InterestRate = 0.0625 },
                new LoanRate() { LowerCreditScore = 80, UpperCreditScore = 89, InterestRate = 0.0525 },
                new LoanRate() { LowerCreditScore = 90, UpperCreditScore = 100, InterestRate = 0.040 }
            };

        #endregion




        [TestMethod]
        public void TestLoanDeniedForLowCreditScore()
        {
            // Arrange
            var application = new LoanApplication()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualIncome = 50_000,
                CreditScore = 47,
                LoanAmount = 250_000,
                Term = LoanTerm.YEARS_30
            };
            LoanProcessingService service = new LoanProcessingService(Rates,
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            );


            // Act
            var result = service.ProcessLoan(application);

            // Assert
            Assert.IsFalse(result.Approved);
        }

        [TestMethod]
        public void TestLoanApprovedForHighCreditScore()
        {
            var application = new LoanApplication()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualIncome = 50_000,
                CreditScore = 77,
                LoanAmount = 250_000,
                Term = LoanTerm.YEARS_30
            };
            LoanProcessingService service = new LoanProcessingService(Rates,
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            );

            // Act
            var result = service.ProcessLoan(application);

            Assert.IsTrue(result.Approved);
        }


        [TestMethod]
        public void TestLoanHasCorrectInterestRate()
        {
            // Arrange
            var application = new LoanApplication()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualIncome = 50_000,
                CreditScore = 73,
                LoanAmount = 250_000,
                Term = LoanTerm.YEARS_30
            };
            LoanProcessingService service = new LoanProcessingService(Rates,
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            );

            // Act
            var result = service.ProcessLoan(application);

            // Assert
            Assert.IsNotNull(result.InterestRate, "This loan should be approved and have an interest rate");
            Assert.AreEqual(0.0625, result.InterestRate.Value);
        }


        [TestMethod]
        public void TestLoanHasCorrectPaymentCalculated()
        {
            // Arrange
            var application = new LoanApplication()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualIncome = 50_000,
                CreditScore = 73,
                LoanAmount = 250_000,
                Term = LoanTerm.YEARS_30
            };
            LoanProcessingService service = new LoanProcessingService(Rates,
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            );

            // Act
            var result = service.ProcessLoan(application);

            // Assert
            Assert.IsNotNull(result.MonthlyPayment);
            Assert.AreEqual(1539.29, result.MonthlyPayment.Value);
        }


        [TestMethod]
        public void TestLoansOverOneMillionDolalrsShouldBeDenied()
        {
            // Arrange
            var application = new LoanApplication()
            {
                FirstName = "John",
                LastName = "Doe",
                AnnualIncome = 250_000,
                CreditScore = 95,
                LoanAmount = 1_000_001,
                Term = LoanTerm.YEARS_30
            };
            LoanProcessingService service = new LoanProcessingService(Rates,
                new CreditScoreLoanApprovalRule(),
                new LoanSizeLoanApprovalRule()
            );

            // Act
            var result = service.ProcessLoan(application);

            // Assert
            Assert.IsFalse(result.Approved);
        }


    }
}
