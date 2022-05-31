

namespace СollectionСomparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int minDimension = 1;
            const int maxDimension = 6;
            const int maxTableWidth = 40;
            const char tableBorderSign = '+';

            int tableDimension;

            do
            {
                Console.WriteLine("Введите размерность таблицы - целое число от 1 до 6:");
            } while (!int.TryParse(Console.ReadLine(), out tableDimension) || IsNumberOutOfRange(tableDimension, minDimension, maxDimension));

            string userTest;

            do
            {
                Console.WriteLine("Введите произвольный текст:");
                userTest = Console.ReadLine();
            } while (userTest.Length == 0);

            var tableWidth = CalculateTableWidth(tableDimension, maxTableWidth, userTest);

            var firstRow = CreateRowWithPadding(userTest, tableDimension - 1, tableWidth);
            var firstStringHeight = firstRow.Count;
            var secondRow = CreateChessRow(tableBorderSign, firstStringHeight, tableWidth);

            PrintHorizontalBorder(tableWidth, tableBorderSign);

            PrintStringsWithLeftRightBorder(firstRow, tableBorderSign);

            PrintHorizontalBorder(tableWidth, tableBorderSign);

            PrintStringsWithLeftRightBorder(secondRow, tableBorderSign);

            PrintHorizontalBorder(tableWidth, tableBorderSign);
        }


        private static List<string> CreateRowWithPadding(string str, int paddingValue, int tableWidth)
        {
            List<char[]> ss = str.Chunk(tableWidth - 2 * (paddingValue + 1)).ToList();
            List<string> s = new List<string>();

            foreach (var item in ss)
            {
                s.Add(new string(item));
            }

            string whitespaces = new string(' ', paddingValue);

            for (int i = 0; i < s.Count; i++)
            {
                s[i] = $"{whitespaces}{s[i]}".PadRight(tableWidth - 2, ' ');
            }

            var emptyString = new string(' ', tableWidth - 2);
            var emptyStringList = new List<string>();

            for (int i = 0; i < paddingValue; i++)
            {
                emptyStringList.Add(emptyString);
            }

            s.InsertRange(0, emptyStringList);
            s.AddRange(emptyStringList);

            return s;
        }

        private static List<string> CreateChessRow(char sign, int height, int tableWidth)
        {
            var s = new List<string>();
            
            for (int i = 0; i < height; i++)
            {
                var str = "";

                for (int j = 0; j < tableWidth - 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        str += ' ';
                    }
                    else
                    {
                        str += sign;
                    }
                }

                if (i % 2 == 0)
                {
                    str = str.Substring(1) + sign;
                }

                s.Add(str);
            }

            return s;
        }

        
        private static bool IsNumberOutOfRange(int number, int min, int max)
        {
            return number < min && number > max;
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

        private static void PrintStringsWithLeftRightBorder(List<string> strings, char tableBorderSign)
        {
            foreach (var strg in strings)
            {
                Console.WriteLine(tableBorderSign + strg + tableBorderSign);
            }
        }
    }
}