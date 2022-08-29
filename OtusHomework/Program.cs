namespace OtusHomework
{
    internal class Program
    {
        static void Main()
        {
            var downloader = new ImageDownloader();

            downloader.DownloadStarted += () => Console.WriteLine("Скачивание файла началось");
            downloader.DownloadCompleted += () => Console.WriteLine("Скачивание файла закончилось");

            downloader.Download();

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}