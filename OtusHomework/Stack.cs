namespace OtusHomework
{
    public class Stack
    {
        public int Size => _elements.Count();

        public string Top
        {
            get
            {
                if (Size == 0)
                {
                    return null;
                }

                return _elements[_elements.Count - 1];
            }
        }

        private List<string> _elements = new List<string>();

        public Stack(params string[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Add(elements[i]);
            }
        }

        public static Stack Concat(params Stack[] stacks)
        {
            var finalStack = new Stack();

            foreach (var stack in stacks)
            {
                finalStack.Merge(stack);
            }

            return finalStack;
        }

        public void Add(string element)
        {
            _elements.Add(element);
        }

        public string Pop()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Стек пустой");
            }

            var lastElement = Top;
            _elements.RemoveAt(_elements.Count - 1);

            return lastElement;
        }
    }
}
