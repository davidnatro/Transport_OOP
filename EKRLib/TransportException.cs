using System;
using System.Runtime.Serialization;

namespace EKRLib
{
    /// <summary>
    /// Класс отвечающий за выброс исключений.
    /// </summary>
    [Serializable]
    public class TransportException : Exception
    {
        public TransportException()
        {
        }

        public TransportException(string message) : base(message)
        {
        }

        public TransportException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransportException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}