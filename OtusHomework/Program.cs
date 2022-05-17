using System.Collections;
using System.Diagnostics;

namespace СollectionСomparison
{
    internal class Program
    {
        private static int _collectionLength = 1000000;
        private static int _elementIndex = 496753;

        static void Main(string[] args)
        {
            var list = new List<int>();
            var listDefinedLength = new List<int>(_collectionLength);
            var arrayList = new ArrayList();
            var arrayListDefinedLength = new ArrayList(_collectionLength);
            var linkedList = new LinkedList<int>();

            var feelTimes = new List<TimeSpan>()
            {
                PrintElapsedTime(FeelCollection, list as ICollection<int>),
                PrintElapsedTime(FeelCollection, listDefinedLength as ICollection<int>),
                PrintElapsedTime(FeelCollection, arrayList),
                PrintElapsedTime(FeelCollection, arrayListDefinedLength),
                PrintElapsedTime(FeelCollection, linkedList)
            };

            var findTimes = new List<TimeSpan>()
            {
                PrintElapsedTime(FindElement, list),
                PrintElapsedTime(FindElement, listDefinedLength),
                PrintElapsedTime(FindElement, arrayList),
                PrintElapsedTime(FindElement, arrayListDefinedLength),
                PrintElapsedTime(linkedList)
            };

            var scanTimes = new List<TimeSpan>()
            {
                PrintElapsedTime(PrintMultiplesOf777, list as ICollection<int>),
                PrintElapsedTime(PrintMultiplesOf777, listDefinedLength as ICollection<int>),
                PrintElapsedTime(PrintMultiplesOf777, arrayList),
                PrintElapsedTime(PrintMultiplesOf777, arrayListDefinedLength),
                PrintElapsedTime(PrintMultiplesOf777, linkedList)
            };

            Console.Clear();

            Console.Write("Заполнение");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\t" + feelTimes[i]);
            }

            Console.WriteLine();

            Console.Write("Поиск");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\t" + findTimes[i]);
            }

            Console.WriteLine();

            Console.Write("% 777");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\t" + scanTimes[i]);
            }
        }

        private static TimeSpan PrintElapsedTime(Action<ICollection<int>> codeToMeasure, ICollection<int> collection)
        {
            var sw = new Stopwatch();

            sw.Start();
            codeToMeasure(collection);
            sw.Stop();

            return sw.Elapsed;
        }

        private static TimeSpan PrintElapsedTime(Action<IList> codeToMeasure, IList collection)
        {
            var sw = new Stopwatch();

            sw.Start();
            codeToMeasure(collection);
            sw.Stop();

            return sw.Elapsed;
        }

        private static TimeSpan PrintElapsedTime(LinkedList<int> collection)
        {
            var sw = new Stopwatch();

            sw.Restart();
            collection.Find(_elementIndex + 1);
            sw.Stop();

            return sw.Elapsed;
        }

        private static void FeelCollection(ICollection<int> collection)
        {
            for (int i = 0; i < _collectionLength - 1; i++)
            {
                collection.Add(i + 1);
            }
        }

        private static void FeelCollection(IList collection)
        {
            for (int i = 0; i < _collectionLength - 1; i++)
            {
                collection.Add(i + 1);
            }
        }

        private static void FindElement(IList collection)
        {
            var element = collection[_elementIndex];
        }

        private static void PrintMultiplesOf777(ICollection<int> collection)
        {
            foreach (var element in collection)
            {
                if (element % 777 == 0)
                {
                    Console.Write($"{element} ");
                }
            }

            Console.WriteLine();
        }

        private static void PrintMultiplesOf777(IList collection)
        {
            foreach (var element in collection)
            {
                if ((int)element % 777 == 0)
                {
                    Console.Write($"{(int)element} ");
                }
            }

            Console.WriteLine();
        }
    }
}
