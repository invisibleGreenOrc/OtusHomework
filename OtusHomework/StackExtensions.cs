namespace OtusHomework
{
    public static class StackExtensions
    {
        public static Stack Merge(this Stack stack, Stack stackToAdd)
        {
            while (stackToAdd.Size != 0)
            {
                stack.Add(stackToAdd.Pop());
            }

            return stack;
        }
    }
}
