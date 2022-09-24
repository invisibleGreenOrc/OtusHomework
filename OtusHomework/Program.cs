namespace OtusHomework
{
    internal class Program
    {
        private static readonly ConsoleKey _keyToExit = ConsoleKey.A;

        static void Main()
        {
            var loader = new ImageLoader();

            loader.DownloadStarted += () => Console.WriteLine("Скачивание файла началось");
            loader.DownloadCompleted += () => Console.WriteLine("Скачивание файла закончилось");

            var downloadTask = loader.DownloadAsync();

            while (true)
            {
                Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");

                var pressedKey = Console.ReadKey(true).Key;

                if (pressedKey == _keyToExit)
                {
                    Environment.Exit(0);
                }

                if (downloadTask.IsCompleted)
                {
                    Console.WriteLine("Уже загружена\n");
                }
                else
                {
                    Console.WriteLine("Еще не загружена\n");
                }
            }
        }
    }
}