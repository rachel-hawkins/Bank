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
            this.WealthyLoaner = new Account(10000);
            this.PoorLoaner = new Account(100);
            this.GoodLoan = new Loan(10000, 3.0f, WealthyLoaner, 10);
            this.BadLoan = new Loan(10000, 3.0f, PoorLoaner, 2);
        }

        [Test]
        public void Test1_CalculatePayments()
        {
            Assert.AreEqual(1030, GoodLoan.CalculatePayments());
        }
  
        [Test]
        public void Test2_EligibilityGood()
        {
            Assert.IsTrue(GoodLoan.CalculateEligibility());
        }

        [Test]
        public void Test3_EligibilityBad()
        {
            Assert.IsFalse(BadLoan.CalculateEligibility());
        }

        [Test]
        public void Test4_LoanInterest()
        {
            Assert.AreEqual(12, GoodLoan.Interest(400));
        }

        [Test]
        public void Test5_MakeGoodPayment()
        {
            GoodLoan.MakePayment(2000);

            Assert.AreEqual(8000, WealthyLoaner.Balance());
            Assert.AreEqual(8000, GoodLoan.Amount());
        }
        [Test]
        public void Test6_MakeBadPayment()
        {
            BadLoan.MakePayment(2000);

            Assert.AreEqual(100, PoorLoaner.Balance());
            Assert.AreEqual(10000, BadLoan.Amount());
        }
    }
}
