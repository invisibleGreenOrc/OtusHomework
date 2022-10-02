using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace JackHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var part1 = new Part(new List<string>
            {
                "Вот дом,",
                "Который построил Джек."
            });

            var part2 = new Part(new List<string>
            {
                "А это пшеница,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            var part3 = new Part(new List<string>
            {
                "А это веселая птица-синица,",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            var part4 = new Part(new List<string>
            {
                "Вот кот,",
                "Который пугает и ловит синицу,",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            var part5 = new Part(new List<string>
            {
                "Вот пес без хвоста,",
                "Который за шиворот треплет кота,",
                "Который пугает и ловит синицу,",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            var part6 = new Part(new List<string>
            {
                "А это корова безрогая,",
                "Лягнувшая старого пса без хвоста,",
                "Который за шиворот треплет кота,",
                "Который пугает и ловит синицу,",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            var part7 = new Part(new List<string>
            {
                "А это старушка, седая и строгая,",
                "Которая доит корову безрогую,",
                "Лягнувшую старого пса без хвоста,",
                "Который за шиворот треплет кота,",
                "Который пугает и ловит синицу,",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            var part8 = new Part(new List<string>
            {
                "А это ленивый и толстый пастух,",
                "Который бранится с коровницей строгою,",
                "Которая доит корову безрогую,",
                "Лягнувшую старого пса без хвоста,",
                "Который за шиворот треплет кота,",
                "Который пугает и ловит синицу,",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            var part9 = new Part(new List<string>
            {
                "Вот два петуха,",
                "Которые будят того пастуха,",
                "Который бранится с коровницей строгою,",
                "Которая доит корову безрогую,",
                "Лягнувшую старого пса без хвоста,",
                "Который за шиворот треплет кота,",
                "Который пугает и ловит синицу,",
                "Которая часто ворует пшеницу,",
                "Которая в темном чулане хранится",
                "В доме,",
                "Который построил Джек."
            });

            part1.AddPart(ImmutableList<string>.Empty);
            part2.AddPart(part1.Poem);
            part3.AddPart(part2.Poem);
            part4.AddPart(part3.Poem);
            part5.AddPart(part4.Poem);
            part6.AddPart(part5.Poem);
            part7.AddPart(part6.Poem);
            part8.AddPart(part7.Poem);
            part9.AddPart(part8.Poem);

            Print(part1.Poem);
            Print(part2.Poem);
            Print(part3.Poem);
            Print(part4.Poem);
            Print(part5.Poem);
            Print(part6.Poem);
            Print(part7.Poem);
            Print(part8.Poem);
            Print(part9.Poem);
        }

        private static void Print(IEnumerable<string> strings)
        {
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
        }
    }
}