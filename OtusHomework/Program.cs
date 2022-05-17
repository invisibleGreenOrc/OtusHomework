using System.Collections;
using System.Diagnostics;

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
            Console.SetCursorPosition(cursorPosition.Left, cursorPosition.Top + 10);


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