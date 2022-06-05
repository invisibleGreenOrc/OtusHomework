using System.Runtime.Serialization;

namespace ExceptionHandling
{
    [Serializable]
    internal class OperandNotIntegerException : Exception
    {
        public OperandNotIntegerException()
        {
        }

        public OperandNotIntegerException(string? message) : base(message)
        {
        }

        public OperandNotIntegerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected OperandNotIntegerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}