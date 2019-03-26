using System;
using System.Runtime.Serialization;

namespace Bank
{
    [Serializable]
    internal class CustomerNotAllowedCloseAccountException : Exception
    {
        public CustomerNotAllowedCloseAccountException()
        {
        }

        public CustomerNotAllowedCloseAccountException(string message) : base(message)
        {
        }

        public CustomerNotAllowedCloseAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotAllowedCloseAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}