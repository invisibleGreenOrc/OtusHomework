namespace OtusHomework
{
    internal class Program
    {
        static void Main()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var newList = list.Top(30);
            Print(newList);

            var listP = new List<Person>();

            for (int i = 1; i < 10; i++)
            {
                listP.Add(new Person { Age = i * 10 });
            }

            var newListP = listP.Top(30, x => x.Age);
            Print(newListP);

            Console.ReadKey();
        }

        private static void Print<T>(IEnumerable<T> listToPrint)
        {
            var textToPrint = string.Join(", ", listToPrint.Select(x => x?.ToString()));
            Console.WriteLine(textToPrint);
        }
    }
}