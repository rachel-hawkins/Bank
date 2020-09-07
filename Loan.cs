using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Loan
    {
        private float amount;
        private float rate;
        private Account acc;
        private int NoOfRepayments;

        public Loan(float amount, float rate, Account acc, int NoOfRepayments)
        {
            this.amount = amount;
            this.acc = acc;
            this.NoOfRepayments = NoOfRepayments;
            this.rate = rate;
        }

        public bool CalculateEligibility()
        {
            //eligible if the account has enough money for the first payment.
            if (this.acc.Balance() >= CalculatePayments())
            {
                return true;
            }
            return false;
        }

        public float CalculatePayments()
        {
            return (this.amount / this.NoOfRepayments) + Interest(this.amount / this.NoOfRepayments); 
        }

        public void MakePayment(float payment)
        {
            if (this.amount-payment > 0 && this.acc.Balance() >= payment)
            {
                this.acc.Withdraw(payment);
                this.amount -= payment;
            }
        }

        public float Interest(float sum)
        {
            return (this.rate/100) * sum;
        }

        public float Amount()
        {
            return this.amount;
        }
    }
}
