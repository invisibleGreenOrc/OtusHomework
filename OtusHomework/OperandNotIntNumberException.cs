using System.Runtime.Serialization;

namespace ExceptionHandling
{
    [Serializable]
    internal class OperandNotIntNumberException : Exception
    {
        public OperandNotIntNumberException()
        {
        }

        public OperandNotIntNumberException(string? message) : base(message)
        {
        }

        public OperandNotIntNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OperandNotIntNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}