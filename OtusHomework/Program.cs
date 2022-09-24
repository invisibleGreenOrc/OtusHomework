namespace RegularCustomer
{
    internal class Program
    {
        private const ConsoleKey _keyToAddProduct = ConsoleKey.A;
        private const ConsoleKey _keyToDeleteProduct = ConsoleKey.D;
        private const ConsoleKey _keyToExit = ConsoleKey.X;

        static void Main()
        {
            var shop = new Shop();
            var customer = new Customer();

            shop.Products.CollectionChanged += customer.OnItemChanged;

            while (true)
            {
                ShowMenu();

                var keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case _keyToAddProduct:
                        shop.Add(GetProductName());
                        break;
                    case _keyToDeleteProduct:
                        Console.WriteLine("Какой товар удалить (id)?");

                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            shop.Remove(productId);
                        }
                        break;
                    case _keyToExit:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static string GetProductName()
        {
            var currentData = DateTime.Now;
            return $"Товар от {currentData}";
        }

        private static void ShowMenu()
        {
            var menuDescription = $"{_keyToAddProduct} - добавить товар, {_keyToDeleteProduct} - удалить товар, {_keyToExit} - выйти.";

            Console.WriteLine(menuDescription);
        }
    }
}