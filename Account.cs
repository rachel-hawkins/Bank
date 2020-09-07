using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Account
    {
        private float balance;
        private static float minbalance = 0;

        public Account()
        {
            this.balance = 0.0f;
        }

        public Account(float balance)
        {
            this.balance = balance;
        }

        public float Balance()
        {
            return this.balance;
        }

        public void Deposit(float amount)
        {
            this.balance += Math.Abs(amount);
        }

        public void Withdraw(float amount)
        {
            if (this.balance - amount > minbalance)
            {
                this.balance -= Math.Abs(amount);
            }
        }

        public Account Transfer(Account destination, float amount)
        {
            amount = Math.Abs(amount);
            if (this.balance - amount > minbalance)
            {
                destination.Deposit(amount);
                this.balance -= amount;
            }
    
            return destination;
        }

    }
}
