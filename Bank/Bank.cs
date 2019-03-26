using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank:IBank 
    {
        private List<Account> ListOfAccount = new List<Account>();
        private List<Customer> ListOfCustomer = new List<Customer>();
        private Dictionary<int, Customer> DCustomerID = new Dictionary<int, Customer>();
        private Dictionary<int, Customer> DCustomerNumber = new Dictionary<int, Customer>();
        private Dictionary<int, Account> DAccountNumber = new Dictionary<int, Account>();
        private Dictionary<Customer, List<Account>> DCustomer = new Dictionary<Customer, List<Account>>();
        private int TotalMoneyInBank;
        private int Profits;
        

        public string Name => throw new NotImplementedException();

        public string Address => throw new NotImplementedException();

        public int CustomerCount => throw new NotImplementedException();

        internal Customer GetCustomerByID(int CustomerID)
        {
            if (DCustomerID.TryGetValue(CustomerID, out Customer A))
                return A;
            throw new CustomerNotFoundException();
        }

        internal Customer GetCustomerByNumber(int CustomerNumber)
        {
            if (DCustomerNumber.TryGetValue(CustomerNumber, out Customer A))
                return A;
            throw new CustomerNotFoundException();

        }

        internal Account GetAccountByNumber(int AccountNumber)
        {
            if (DAccountNumber.TryGetValue(AccountNumber, out Account Z))
                return Z;
            throw new AccountNumberNotFoundException();

        }

        internal List<Account> GetAccountByCustomer(Customer A)
        {
            if (DCustomer.TryGetValue(A, out List<Account> Z))
                return Z;
            throw new CustomerNotFountException();

        }

        public void AddNewCustomer(Customer A)
        {
            if (A == null)
            {
                throw new CustomerNullException();
            }

            if (ListOfCustomer.Contains(A))
            {
                throw new CustomerAlreadyExistException();
            }
            else
            {
                ListOfCustomer.Add(A);
                DCustomerID.Add(A.CustomerID, A);
                DCustomerNumber.Add(A.CustomerNumber, A);

            }
        }


        internal void AddNewAccount(Customer accountOwner, Account Z)
        {
            if (Z == null)
            {
                throw new AccountNullException();
            }

            if (ListOfAccount.Contains(Z))
            {
                throw new AccountAlreadyExistException();
            }
            else
            {
                ListOfAccount.Add(Z);
                DAccountNumber.Add(Z.AccountNumber, Z);
                List<Account> ZList = new List<Account>();
                ZList.Add(Z);
                TotalMoneyInBank = TotalMoneyInBank + Z.Balance;
            }
        }


        internal int Deposit(Account Z, int Amount)
        {
            if (ListOfAccount.Contains(Z))
            {
                Z.Add(Amount);
                TotalMoneyInBank = TotalMoneyInBank + Amount;
                return Z.Balance;
            }
            else
            {
                throw new AccountNotFoundException();
            }
        }

        internal int Withdraw(Account Z, int Amount)
        {
            if (ListOfAccount.Contains(Z))
            {
                Z.Subtract(Amount);
                TotalMoneyInBank = TotalMoneyInBank - Amount;
                return Z.Balance;
            }
            else
            {
                throw new AccountNotFoundException();
            }
        }

        internal int GetCustomerTotalBalance(Customer A)
        {
            int sum = 0;
            DCustomer.TryGetValue(A, out List<Account> listA);
            foreach (Account Z in listA)
            {
                sum = sum + Z.Balance;
            }
            return sum;
        }

        internal void CloseAccount(Account Z, Customer A)
        {
            if (ListOfAccount.Contains(Z) && ListOfCustomer.Contains(A))
            {
                if (Z.Balance < 0)
                    throw new CustomerNotAllowedCloseAccountException();
                ListOfAccount.Remove(Z);
                DAccountNumber.Remove(Z.AccountNumber);
                ListOfCustomer.Remove(A);
                DCustomer.Remove(A);
                DCustomerID.Remove(A.CustomerID);
                DCustomerNumber.Remove(A.CustomerNumber);
                TotalMoneyInBank = TotalMoneyInBank - Z.Balance;
            }
            else
            {
                if (!ListOfCustomer.Contains(A) && !ListOfAccount.Contains(Z))
                    throw new AccountAndCustomerNotFoundException();
                if (!ListOfCustomer.Contains(A))
                    throw new CustomerNotFountException();
                if (!ListOfAccount.Contains(Z))
                    throw new AccountNotFoundException();
            }

        }

        internal void ChargeAnnualCommossion(float percentage)
        {
            float x = 0;
            foreach (Account Z in ListOfAccount)
            {
                if (Z.Balance < Z.MaxMinusAllowed)
                {
                    percentage = percentage * 2.0f;
                }
                x = percentage * Z.Balance / 100.0f;
                Z.Subtract(Convert.ToInt32(x));
                Profits = Profits + Convert.ToInt32(x);
            }
        }

        internal void JoinAccounts(Account Z1, Account Z2)
        {
            Account Z3 = Z1 + Z2; 
            CloseAccount(Z1, Z1.AccountOwner);
            CloseAccount(Z2, Z2.AccountOwner);
            AddNewCustomer(Z3.AccountOwner);
            AddNewAccount(Z3.AccountOwner, Z3);
        }

        public Bank()
        {
        }
    }

    [Serializable]
    internal class AccountNullException : Exception
    {
        public AccountNullException()
        {
        }

        public AccountNullException(string message) : base(message)
        {
        }

        public AccountNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
