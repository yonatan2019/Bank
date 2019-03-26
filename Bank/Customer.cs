using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Customer
    {
        private static int numberOfCust;
        private readonly int customerID;
        private readonly int customerNumber;
         public string Name { get; private set; }
         public int CustomerID { get;}
         public int CustomerNumber { get;}

        public Customer(string name, int customerID, int Phone)
        {
            Name = name;
            CustomerID = customerID;
            CustomerNumber = Phone;
        }

        public static bool operator ==(Customer A1, Customer A2)
        {
            if (A1.CustomerNumber == A2.CustomerNumber)
                return true;
            return false;
        }

        public static bool operator !=(Customer A1, Customer A2)
        {
            if (A1.CustomerNumber != A2.CustomerNumber)
                return true;
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is Customer)
            {
                Customer A = obj as Customer;
                return this == A;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.CustomerNumber;
        }

        public override string ToString()
        {
            return $"name: {Name}, id: {CustomerID}, number of customer: {CustomerNumber}";
        }



    }
}
