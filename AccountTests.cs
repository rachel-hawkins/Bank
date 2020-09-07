using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;
using NUnit.Framework;

namespace Bank
{
    [TestFixture]

    class AccountTests
    {
        Account source;
        Account destination;

        [SetUp]
        public void SetUpTests()
        {
            this.source = new Account();
            this.destination = new Account();
        }

        [Test]
        public void Test_Deposit()
        {
            source.Deposit(100);
            Assert.AreEqual(source.Balance(), 100.00);
        }

        [Test]
        public void Test_DepositNeg()
        {
            this.SetAccountValue(source, 0);
            source.Deposit(-100);
            Assert.AreEqual(source.Balance(), 100.00);
        }

        [Test]
        public void Test_Withdraw()
        {
            this.SetAccountValue(source, 100);
            source.Withdraw(10);
            Assert.AreEqual(source.Balance(), 90);
        }

        [Test]
        public void Test_WithdrawPos()
        {
            this.SetAccountValue(source, 400);
            source.Withdraw(-100);
            Assert.AreEqual(source.Balance(), 300.00);
        }

        [Test]
        public void Test_WithdrawNotBelow()
        {
            this.SetAccountValue(source , 100);
            source.Withdraw(100);
            Assert.AreEqual(source.Balance(), 0.0f);
        }

        [Test]
        public void Test_WithdrawMore()
        {
            this.SetAccountValue(source, 100);
            source.Withdraw(1000);
            Assert.AreEqual(source.Balance(), 100);
        }

        //Helper
        public void SetAccountValue(Account acc, float amount)
        {
            acc.Withdraw(acc.Balance());
            acc.Deposit(amount);
        }


    }
}
