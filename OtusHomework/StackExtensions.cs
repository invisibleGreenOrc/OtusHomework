namespace OtusHomework
{
    public static class StackExtensions
    {
        public static Stack Merge(this Stack stack, Stack stackToAdd)
        {
            while (stackToAdd.Top is not null)
            {
                stack.Add(stackToAdd.Pop());
            }

            return stack;
        }
    }
}
