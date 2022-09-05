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

            try
            {
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed: {e.Message}");
            }

            Console.ReadKey();
        }

        private static List<string> CreateDirectories(string sourceDirPath, string baseName, int quantity)
        {
            var directoriesPaths = new List<string>();

            for (int i = 1; i <= quantity; i++)
            {
                var path = Path.Combine(sourceDirPath, $"{baseName}{i}");
                new DirectoryInfo(path).Create();
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
            File.AppendAllText(filePath, data, Encoding.UTF8);
        }

        private static void PrintDataFromFile(string filePath)
        {
            Console.WriteLine($"{Path.GetFileName(filePath)}: {File.ReadAllText(filePath)}");
        }
    }
}