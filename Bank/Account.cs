using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Account
    {
        private static int NumberOfAcc;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;
        public int AccountNumber { get;}
        public int Balance { get;private set; }
        public Customer AccountOwner { get; }
        public int MaxMinusAllowed { get; }


        public Account (Customer A , int MonthlyInCome)
        {
            NumberOfAcc++;
            accountNumber = NumberOfAcc;
            maxMinusAllowed = MonthlyInCome;
        }

        public void Add(int Amount)
        {
            Balance = Balance + Amount;
        }
        
        public void Subtract (int Amount)
        {
            if (this.Balance < this.MaxMinusAllowed)
                throw new BalanceException();
            int check = this.Balance - Amount;
            if (check < this.MaxMinusAllowed)
                throw new BalanceException();
            Balance = Balance - Amount;
        }

        public static bool operator == (Account z1 , Account Z2)
        {
            if (z1.AccountNumber == Z2.AccountNumber)
                return true;
            return false;
        }

        public static bool operator != (Account Z1 , Account Z2)
        {
            if (Z1.AccountNumber != Z2.AccountNumber)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Account)
            {
                Account Z1 = obj as Account;
                return this == Z1;

            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.AccountNumber;
        }

        public override string ToString()
        {
            return $"Account Number:{AccountNumber}";
        }


    }
}
