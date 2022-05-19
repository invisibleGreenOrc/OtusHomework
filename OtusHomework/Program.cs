using System.Collections;
using System.Diagnostics;
using System.Text;

namespace СollectionСomparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var collectionLength = 1000000;
            var elementIndex = 496753;
            var divisor = 777;

            var list = new List<int>();
            var arrayList = new ArrayList();
            var linkedList = new LinkedList<int>();

            var elapsedTimes = new Dictionary<string, TimeSpan>();

            var sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < collectionLength; i++)
            {
                list.Add(i + 1);
            }

            sw.Stop();
            elapsedTimes.Add("List", sw.Elapsed);

            sw.Restart();

            for (int i = 0; i < collectionLength; i++)
            {
                arrayList.Add(i + 1);
            }

            sw.Stop();
            elapsedTimes.Add("ArrayList", sw.Elapsed);

            sw.Restart();

            for (int i = 0; i < collectionLength; i++)
            {
                linkedList.AddLast(i + 1);
            }

            sw.Stop();
            elapsedTimes.Add("LinkedList", sw.Elapsed);

            Console.WriteLine($"### Время заполнения {collectionLength} элементов ###");
            PrintTimes(elapsedTimes);


            int elementValue;

            sw.Restart();
            elementValue = list[elementIndex];
            sw.Stop();

            elapsedTimes["List"] = sw.Elapsed;

            sw.Restart();
            elementValue = Convert.ToInt32(arrayList[elementIndex]);
            sw.Stop();

            elapsedTimes["ArrayList"] = sw.Elapsed;

            sw.Restart();
            elementValue = GetElementValueByIndex(linkedList, elementIndex);
            sw.Stop();

            elapsedTimes["LinkedList"] = sw.Elapsed;

            Console.WriteLine($"### Время поиска элемента с индексом {elementIndex}  ###");
            PrintTimes(elapsedTimes);


            var cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top + 50);


            sw.Restart();
            
            foreach (var item in list)
            {
                if (item % divisor == 0)
                {
                    Console.Write($"{item} ");
                }
            }

            sw.Stop();
            elapsedTimes["List"] = sw.Elapsed;

            sw.Restart();

            foreach (var item in arrayList)
            {
                if (Convert.ToInt32(item) % divisor == 0)
                {
                    Console.Write($"{item} ");
                }
            }

            sw.Stop();
            elapsedTimes["ArrayList"] = sw.Elapsed;

            sw.Restart();

            foreach (var item in linkedList)
            {
                if (item % divisor == 0)
                {
                    Console.Write($"{item} ");
                }
            }

            sw.Stop();
            elapsedTimes["LinkedList"] = sw.Elapsed;

            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

            Console.WriteLine($"### Время вывода элементов, кратных {divisor} ###");
            PrintTimes(elapsedTimes);


            cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top + 50);

            var result = string.Empty;
            sw.Restart();

            foreach (var item in list)
            {
                if (item % divisor == 0)
                {
                    result += $"{item} ";
                }
            }

            Console.WriteLine(result);

            sw.Stop();
            elapsedTimes["List"] = sw.Elapsed;

            result = string.Empty;
            sw.Restart();

            foreach (var item in arrayList)
            {
                if (Convert.ToInt32(item) % divisor == 0)
                {
                    result += $"{item} ";
                }
            }

            Console.WriteLine(result);

            sw.Stop();
            elapsedTimes["ArrayList"] = sw.Elapsed;

            result = string.Empty;
            sw.Restart();

            foreach (var item in linkedList)
            {
                if (item % divisor == 0)
                {
                    result += $"{item} ";
                }
            }

            Console.WriteLine(result);

            sw.Stop();
            elapsedTimes["LinkedList"] = sw.Elapsed;

            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

            Console.WriteLine($"### Время вывода элементов, кратных {divisor}\n" +
                $"Сначала в строку, потом на консоль ###");
            PrintTimes(elapsedTimes);


            cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top + 50);

            var sb = new StringBuilder();
            sw.Restart();

            foreach (var item in list)
            {
                if (item % divisor == 0)
                {
                    sb.Append($"{item} ");
                }
            }

            Console.WriteLine(sb.ToString());

            sw.Stop();
            elapsedTimes["List"] = sw.Elapsed;

            sb.Clear();
            sw.Restart();

            foreach (var item in arrayList)
            {
                if (Convert.ToInt32(item) % divisor == 0)
                {
                    sb.Append($"{item} ");
                }
            }

            Console.WriteLine(sb.ToString());

            sw.Stop();
            elapsedTimes["ArrayList"] = sw.Elapsed;

            sb.Clear();
            sw.Restart();

            foreach (var item in linkedList)
            {
                if (item % divisor == 0)
                {
                    sb.Append($"{item} ");
                }
            }

            Console.WriteLine(sb.ToString());

            sw.Stop();
            elapsedTimes["LinkedList"] = sw.Elapsed;

            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

            Console.WriteLine($"### Время вывода элементов, кратных {divisor}\n" +
                $"Сначала в StringBuilder, потом на консоль ###");
            PrintTimes(elapsedTimes);

            cursorPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top + 50);

            sb.Clear();
            sw.Restart();

            for (int i = 0; i < collectionLength; i++)
            {
                if (list[i] % divisor == 0)
                {
                    sb.Append($"{list[i]} ");
                }
            }

            Console.WriteLine(sb.ToString());

            sw.Stop();
            elapsedTimes["List"] = sw.Elapsed;

            sb.Clear();
            sw.Restart();

            for (int i = 0; i < collectionLength; i++)
            {
                if (Convert.ToInt32(arrayList[i]) % divisor == 0)
                {
                    sb.Append($"{arrayList[i]} ");
                }
            }

            Console.WriteLine(sb.ToString());

            sw.Stop();
            elapsedTimes["ArrayList"] = sw.Elapsed;

            sb.Clear();
            sw.Restart();

            foreach (var item in linkedList)
            {
                if (item % divisor == 0)
                {
                    sb.Append($"{item} ");
                }
            }

            Console.WriteLine(sb.ToString());

            sw.Stop();
            elapsedTimes["LinkedList"] = sw.Elapsed;

            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top);

            Console.WriteLine($"### Время вывода элементов, кратных {divisor}\n" +
                $"Сначала в StringBuilder, потом на консоль ###");
            PrintTimes(elapsedTimes);


            Console.ReadKey();
        }

        private static int GetElementValueByIndex(LinkedList<int> list, int index)
        {
            var i = 0;
            var node = list.First;

            while (i < index)
            {
                i++;
                node = node.Next;
            }

            return node.Value;
        }

        private static void PrintTimes(Dictionary<string, TimeSpan> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key,10}\t{item.Value}");
            }
        }
    }
}