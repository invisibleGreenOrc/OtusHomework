namespace Librarian
{
    internal class Program
    {
        private const ConsoleKey _keyToAddBook = ConsoleKey.D1;
        private const ConsoleKey _keyToShowList = ConsoleKey.D2;
        private const ConsoleKey _keyToExit = ConsoleKey.D3;

        static void Main(string[] args)
        {
            var bookRepository = new Repository();

            while (true)
            {
                ShowMenu();

                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case _keyToAddBook:
                        Console.WriteLine("Введите название книги:");
                        bookRepository.Add(Console.ReadLine()!);
                        break;
                    case _keyToShowList:
                        Console.WriteLine(bookRepository.ToString());
                        break;
                    case _keyToExit:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void ShowMenu()
        {
            var menuDescription = $"{((char)_keyToAddBook)} - добавить книгу, {(char)_keyToShowList} - вывести список непрочитанного, {(char)_keyToExit} - выйти.";

            Console.WriteLine(menuDescription);
        }
    }
}