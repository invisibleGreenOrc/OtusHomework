using System.Text;

namespace ConsoleTable
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
            }
            while (!int.TryParse(Console.ReadLine(), out tableDimension) || IsNumberOutOfRange(tableDimension, minDimension, maxDimension));

            string userTest;

            do
            {
                Console.WriteLine("Введите произвольный текст:");
                userTest = Console.ReadLine();
            }
            while (userTest.Length == 0);

            var tableWidth = CalculateTableWidth(tableDimension, maxTableWidth, userTest);

            var firstRow = CreateRowWithPadding(userTest, tableDimension - 1, tableWidth);
            var firstStringHeight = firstRow.Count;
            var secondRow = CreateChessRow(tableBorderSign, firstStringHeight, tableWidth);
            var thirdRow = CreateCrossRow(tableBorderSign, tableWidth);
            var horizontalBorder = CreateHorizontalBorder(tableWidth, tableBorderSign);

            Console.WriteLine(horizontalBorder);

            for (int rowNumber = 1; rowNumber < 4; rowNumber++)
            {
                switch (rowNumber)
                {
                    case 1:
                        PrintStringsWithLeftRightBorder(firstRow, tableBorderSign);
                        break;
                    case 2:
                        PrintStringsWithLeftRightBorder(secondRow, tableBorderSign);
                        break;
                    case 3:
                        PrintStringsWithLeftRightBorder(thirdRow, tableBorderSign);
                        break;
                }

                Console.WriteLine(horizontalBorder);
            }
        }

        private static List<string> CreateRowWithPadding(string str, int paddingValue, int tableWidth)
        {
            List<char[]> ss = str.Chunk(tableWidth - 2 * (paddingValue + 1)).ToList();
            List<string> row = new List<string>();

            foreach (var item in ss)
            {
                row.Add(new string(item));
            }

            string whitespaces = new string(' ', paddingValue);


            for (int i = 0; i < row.Count; i++)
            {
                row[i] = $"{whitespaces}{row[i]}".PadRight(tableWidth - 2, ' ');
            }

            var emptyString = new string(' ', tableWidth - 2);
            var emptyStringList = new List<string>();

            for (int i = 0; i < paddingValue; i++)
            {
                emptyStringList.Add(emptyString);
            }

            row.InsertRange(0, emptyStringList);
            row.AddRange(emptyStringList);

            return row;
        }

        private static List<string> CreateChessRow(char sign, int height, int tableWidth)
        {
            var row = new List<string>();

            var sourceString = new StringBuilder();
            var sourceStringLength = tableWidth - 1;

            for (int i = 0; i < sourceStringLength; i++)
            {
                sourceString.Append(i % 2 == 0 ? ' ' : sign);
            }

            var oddString = sourceString.ToString(0, sourceStringLength - 1);
            var evenString = sourceString.ToString(1, sourceStringLength - 1);

            for (int i = 0; i < height; i++)
            {
                row.Add(i % 2 == 0 ? evenString : oddString);
            }

            return row;
        }

        private static List<string> CreateCrossRow(char sign, int tableWidth)
        {
            var contentField = new char[tableWidth - 2][];

            for (int i = 0; i < contentField.Length; i++)
            {
                contentField[i] = new char[tableWidth - 2];

                for (int j = 0; j < contentField[i].Length; j++)
                {
                    if ((i == j) || (i + j == contentField.Length - 1))
                    {
                        contentField[i][j] = sign;
                    }
                    else
                    {
                        contentField[i][j] = ' ';
                    }
                }
            }

            var row = new List<string>();

            for (int i = 0; i < contentField.Length; i++)
            {
                row.Add(new string(contentField[i]));
            }

            return row;
        }

        private static bool IsNumberOutOfRange(int number, int min, int max)
        {
            return number < min || number > max;
        }

        private static int CalculateTableWidth(int tableDimension, int maxTableWidth, string userText)
        {
            var proposedWidth = userText.Length + tableDimension * 2;

            return proposedWidth > maxTableWidth ? maxTableWidth : proposedWidth;
        }

        private static string CreateHorizontalBorder(int length, char sign)
        {
            var border = new string(sign, length);
            return border;
        }

        private static void PrintStringsWithLeftRightBorder(List<string> strings, char tableBorderSign)
        {
            var sb = new StringBuilder();

            foreach (var strg in strings)
            {
                sb.Append(tableBorderSign);
                sb.Append(strg);
                sb.Append(tableBorderSign);
                sb.Append('\n');
            }

            Console.Write(sb.ToString());
        }
    }
}