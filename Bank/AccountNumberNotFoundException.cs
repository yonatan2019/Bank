using System;
using System.Runtime.Serialization;

namespace Bank
{
    [Serializable]
    internal class AccountNumberNotFoundException : Exception
    {
        public AccountNumberNotFoundException()
        {
        }

        public AccountNumberNotFoundException(string message) : base(message)
        {
        }

        public AccountNumberNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AccountNumberNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}