using System;
using System.Runtime.Serialization;

namespace Bank
{
    [Serializable]
    internal class CustomerNullException : Exception
    {
        public CustomerNullException()
        {
        }

        public CustomerNullException(string message) : base(message)
        {
        }

        public CustomerNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}