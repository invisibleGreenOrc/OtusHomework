namespace OtusHomework
{
    internal class Item
    {
        public int Key { get; init; }

        public string Value { get; init; }

        public Item(int key, string value)
        {
            Key = key;
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
