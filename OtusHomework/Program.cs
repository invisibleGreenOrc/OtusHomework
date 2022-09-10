namespace OtusHomework
{
    internal class Program
    {
        static void Main()
        {
            var dir = new OtusDictionary();

            dir.Add(0, "0");
            dir.Add(32, "32");
            dir.Add(100, "100");

            Console.WriteLine(dir.Get(0));
            Console.WriteLine(dir.Get(32));
            Console.WriteLine(dir.Get(100));

            dir[1] = "1";
            dir[33] = "33";

            Console.WriteLine(dir.Get(0));
            Console.WriteLine(dir.Get(32));
            Console.WriteLine(dir.Get(100));
            Console.WriteLine(dir[1]);
            Console.WriteLine(dir[33]);

            dir[65] = "65";

            Console.WriteLine(dir.Get(0));
            Console.WriteLine(dir.Get(32));
            Console.WriteLine(dir.Get(100));
            Console.WriteLine(dir[1]);
            Console.WriteLine(dir[33]);
            Console.WriteLine(dir[65]);

            dir[36] = "36";

            Console.ReadKey();
        }
    }
}