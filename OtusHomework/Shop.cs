using System.Collections.ObjectModel;

namespace RegularCustomer
{
    internal class Shop
    {
        public ObservableCollection<Item> Products { get; } = new();

        public void Add(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            var newProduct = new Item(GetNextId(), name);

            Products.Add(newProduct);
        }

        public void Remove(int id)
        {
            var product = Products.Where(x => x.Id == id).FirstOrDefault();

            if (product is not null)
            {
                Products.Remove(product);
            }
            else
            {
                Console.WriteLine($"Продукт с id = {id} не найден");
            }
        }

        private int GetNextId()
        {
            if (Products.Count == 0)
            {
                return 0;
            }

            return Products.Select(x => x.Id).Max() + 1;
        }
    }
}
