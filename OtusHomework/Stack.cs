namespace OtusHomework
{
    public class Stack
    {
        private class StackItem
        {
            public string Value { get; private set; }

            public StackItem? Previous { get; private set; }

            public StackItem(string value, StackItem? previous)
            {
                Value = value;
                Previous = previous;
            }
        }

        public int Size 
        {
            get
            {
                var count = 0;
                var element = _lastElement;

                while (element is not null)
                {
                    count++;
                    element = element.Previous;
                }

                return count;
            } 
        }

        public string? Top => _lastElement?.Value;

        private StackItem? _lastElement;

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

        public void Add(string elementValue)
        {
            var newElement = new StackItem(elementValue, _lastElement);
            _lastElement = newElement;
        }

        public string Pop()
        {
            if (_lastElement is null)
            {
                throw new InvalidOperationException("Стек пустой");
            }

            var lastElementValue = _lastElement.Value;
            _lastElement = _lastElement.Previous;

            return lastElementValue;
        }
    }
}
