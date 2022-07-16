using System.Diagnostics;
using System.Text;

namespace OtusHomework
{
    internal class Program
    {
        public static void Main()
        {
            var sw = new Stopwatch();
            var sb = new StringBuilder();

            var numbersPositions = new[] { 5, 10, 20 };

            for (int j = 0; j < 3; j++)
            {
                sb.AppendLine("Для рекурсии:");

                for (int i = 0; i < numbersPositions.Length; i++)
                {
                    sw.Restart();

                    GetFibonacciNumberRecursion(numbersPositions[i]);

                    sw.Stop();

                    sb.Append("Номер числа: ");
                    sb.Append(numbersPositions[i]);
                    sb.Append(" Время поиска: ");
                    sb.AppendLine(sw.Elapsed.ToString());
                }

                sb.AppendLine("Для цикла:");

                for (int i = 0; i < numbersPositions.Length; i++)
                {
                    sw.Restart();

                    GetFibonacciNumberLoop(numbersPositions[i]);

                    sw.Stop();

                    sb.Append("Номер числа: ");
                    sb.Append(numbersPositions[i]);
                    sb.Append(" Время поиска: ");
                    sb.AppendLine(sw.Elapsed.ToString());
                }
            }

            Console.WriteLine(sb.ToString());

            Console.ReadKey();
        }

        public static int GetFibonacciNumberRecursion(int position)
        {
            if (position == 0 || position == 1)
            {
                return position;
            }
            
            return GetFibonacciNumberRecursion(position - 1) + GetFibonacciNumberRecursion(position - 2);
        }

        public static int GetFibonacciNumberLoop(int position)
        {
            if (position == 0 || position == 1)
            {
                return position;
            }

            var nearbyNumbers = (0, 1);

            for (int i = 2; i <= position; i++)
            {
                nearbyNumbers = (nearbyNumbers.Item2, nearbyNumbers.Item1 + nearbyNumbers.Item2);
            }

            return nearbyNumbers.Item2;
        }
    }
}