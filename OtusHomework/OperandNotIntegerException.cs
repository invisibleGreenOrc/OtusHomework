namespace ExceptionHandling
{
    internal class OperandNotIntegerException : Exception
    {
        public OperandNotIntegerException(string? message) : base(message)
        {
        }
    }
}