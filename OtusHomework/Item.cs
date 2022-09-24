namespace RegularCustomer
{
    internal class Item
    {
        public int Id { get;}

        public string Name { get;}

        public Item(int id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
