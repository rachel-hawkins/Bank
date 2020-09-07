using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using NUnit.Framework;

namespace Bank
{
    [TestFixture]

    class LoanTests
    {
        Account WealthyLoaner;
        Account PoorLoaner;
        Loan GoodLoan;
        Loan BadLoan;

        [SetUp]
        public void SetUpTests()
        {
            this.WealthyLoaner = new Account(1000);
            this.PoorLoaner = new Account(100);
            this.GoodLoan = new Loan(10000, 3.0f, WealthyLoaner, 10);
            this.BadLoan = new Loan(10000, 3.0f, PoorLoaner, 2);
        }

        [Test]
        public void Test_CalculatePayments()
        {
            Assert.AreEqual(GoodLoan.CalculatePayments(), 1030);
        }
  
        [Test]
        public void Test_EligibilityGood()
        {
            Assert.IsTrue(GoodLoan.CalculateEligibility());
        }

        [Test]
        public void Test_EligibilityBad()
        {
            Assert.IsFalse(BadLoan.CalculateEligibility());
        }


        [Test]
        public void Test_LoanInterest()
        {
            Assert.AreEqual(GoodLoan.Interest(400), 12);
        }
    }
}
