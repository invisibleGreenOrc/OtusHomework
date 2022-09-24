using System.Text;

namespace OtusHomework
{
    internal class Program
    {
        static void Main()
        {
            var baseDirectoryPath = @"c:\Otus";
            var baseDirectoryName = "TestDir";
            var numberOfDirectories = 2;

            var directories = CreateDirectories(baseDirectoryPath, baseDirectoryName, numberOfDirectories);

            var baseFileName = "File";
            var numberOfFilesPerDirectory = 10;

            CreateFiles(directories, baseFileName, numberOfFilesPerDirectory);

            var allFiles = Directory.EnumerateFiles(baseDirectoryPath, "*.*", SearchOption.AllDirectories);

            foreach (var file in allFiles)
            {
                WriteDataToFile(file, Path.GetFileName(file));
                WriteDataToFile(file, " " + DateTime.Now);
            }
            foreach (var file in allFiles)
            {
                PrintDataFromFile(file);
            }

            Console.ReadKey();
        }

        private static List<string> CreateDirectories(string sourceDirPath, string baseName, int quantity)
        {
            var directoriesPaths = new List<string>();

            for (int i = 1; i <= quantity; i++)
            {
                var path = Path.Combine(sourceDirPath, $"{baseName}{i}");
                Directory.CreateDirectory(path);
                directoriesPaths.Add(path);
            }

            return directoriesPaths;
        }

        private static void CreateFiles(List<string> directoriesPaths, string baseName, int quantityPerDirectory)
        {
            foreach (var dirPath in directoriesPaths)
            {
                for (int i = 1; i <= quantityPerDirectory; i++)
                {
                    File.Create(Path.Combine(dirPath, $"{baseName}{i}")).Dispose();
                }
            }
        }

        private static void WriteDataToFile(string filePath, string data)
        {
            try
            {
                File.AppendAllText(filePath, data, Encoding.UTF8);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось записать данные в один из файлов. Ошибка: {e.Message}");
            }
        }

        private static void PrintDataFromFile(string filePath)
        {
            try
            {
                Console.WriteLine($"{Path.GetFileName(filePath)}: {File.ReadAllText(filePath)}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось прочитать один из файлов. Ошибка: {e.Message}");
            }
        }
    }
}