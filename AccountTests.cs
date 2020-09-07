using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Utilities;
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
        public void Test1_Deposit()
        {
            source.Deposit(100);
            Assert.AreEqual(100.00, source.Balance());
        }

        [Test]
        public void Test2_DepositNeg()
        {
            this.SetAccountValue(source, 0);
            source.Deposit(-100);
            Assert.AreEqual(100.00, source.Balance());
        }

        [Test]
        public void Test3_Withdraw()
        {
            this.SetAccountValue(source, 100);
            source.Withdraw(10);
            Assert.AreEqual(90, source.Balance());
        }

        [Test]
        public void Test4_WithdrawPos()
        {
            this.SetAccountValue(source, 400);
            source.Withdraw(-100);
            Assert.AreEqual(300, source.Balance());
        }

        [Test]
        public void Test5_WithdrawNotBelow()
        {
            this.SetAccountValue(source , 100);
            this.source.Withdraw(100);
            Assert.AreEqual(0, source.Balance());
        }

        [Test]
        public void Test6_WithdrawMore()
        {
            this.SetAccountValue(source, 100);
            source.Withdraw(1000);
            Assert.AreEqual(100, source.Balance());
        }

        [Test]
        public void Test7_TransferCorrect()
        {
            this.SetAccountValue(source, 100);
            this.SetAccountValue(destination, 0);
            this.source.Transfer(destination, 100);

            //Should work.
            Assert.AreEqual(0, source.Balance());
            Assert.AreEqual(100, destination.Balance());
        }

        [Test]
        public void Test8_TransferIncorrect()
        {
            this.SetAccountValue(source, 100);
            this.SetAccountValue(destination, 0);
            //Try to transfer more than available.
            this.source.Transfer(destination, 400);

            //Should not work.
            Assert.AreEqual(100, source.Balance());
            Assert.AreEqual(0, destination.Balance());
        }

        //Helper
        public void SetAccountValue(Account acc, float amount)
        {
            acc.Withdraw(acc.Balance());
            acc.Deposit(amount);
        }


    }
}
