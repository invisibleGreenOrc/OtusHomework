

namespace СollectionСomparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var minDimension = 1;
            var maxDimension = 6;
            int tableDimension;
            string userTest;

            int maxTableWidth = 40;
            char tableBorderSign = '+';

            do
            {
                Console.WriteLine("Введите размерность таблицы - целое число от 1 до 6:");
            } while (!int.TryParse(Console.ReadLine(), out tableDimension) || !IsNumberInRange(tableDimension, minDimension, maxDimension));

            do
            {
                Console.WriteLine("Введите произвольный текст:");
                userTest = Console.ReadLine();
            } while (userTest.Length == 0);

            var tableWidth = CalculateTableWidth(tableDimension, maxTableWidth, userTest);

            List<char[]> ss = userTest.Chunk(tableWidth - 2 * tableDimension).ToList();
            List<string> s = new List<string>();

            foreach (var item in ss)
            {
                s.Add(new string(item));
            }

            string whitespaces = new string(' ', tableDimension - 1);

            for (int i = 0; i < s.Count; i++)
            {
                s[i] = $"{whitespaces}{s[i]}".PadRight(tableWidth - 2, ' ');
            }

            var emptyString = new string(' ', tableWidth - 2);
            var emptyStringList = new List<string>();

            for (int i = 0; i < tableDimension - 1; i++)
            {
                emptyStringList.Add(emptyString);
            }

            s.InsertRange(0, emptyStringList);
            s.AddRange(emptyStringList);

            

            PrintHorizontalBorder(tableWidth, tableBorderSign);

            foreach (var item in s)
            {
                Console.Write(tableBorderSign);
                Console.Write(item);
                Console.WriteLine(tableBorderSign);
            }

            PrintHorizontalBorder(tableWidth, tableBorderSign);


            Console.ReadLine();
        }

        private static bool IsNumberInRange(int number, int min, int max)
        {
            return number >= min && number <= max;
        }

        private static int CalculateTableWidth(int tableDimension, int maxTableWidth, string userText)
        {
            var proposedWidth = userText.Length + tableDimension * 2;

            return proposedWidth > maxTableWidth ? maxTableWidth : proposedWidth;
        }

        private static void PrintHorizontalBorder(int length, char sign)
        {
            var border = new string(sign, length);
            Console.WriteLine(border);
        }
    }
}