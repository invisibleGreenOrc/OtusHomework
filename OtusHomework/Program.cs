using System.Text;

namespace OtusHomework
{
    internal class Program
    {
        public static void Main()
        {
            var firstPlanet = new 
            {
                Name = "Венера",
                OrdinalNumberFromTheSun = 2,
                EquatorLength = 38025
            };

            var secondPlanet = new
            {
                Name = "Земля",
                OrdinalNumberFromTheSun = 3,
                EquatorLength = 40076,
                PreviousPlanet = firstPlanet
            };

            var thirdPlanet = new
            {
                Name = "Марс",
                OrdinalNumberFromTheSun = 4,
                EquatorLength = 21296,
                PreviousPlanet = secondPlanet
            };

            var fourthPlanet = new
            {
                Name = "Венера",
                OrdinalNumberFromTheSun = 2,
                EquatorLength = 38025,
                PreviousPlanet = thirdPlanet
            };

            var planetToCompare = fourthPlanet;

            var sb = new StringBuilder();

            var isEqual = firstPlanet.Name == planetToCompare.Name
                        && firstPlanet.OrdinalNumberFromTheSun == planetToCompare.OrdinalNumberFromTheSun
                        && firstPlanet.EquatorLength == planetToCompare.EquatorLength ? "Да" : "Нет";
            sb.AppendLine($"Название: {firstPlanet.Name}, порядковый номер от Солнца: {firstPlanet.OrdinalNumberFromTheSun}, длина экватора: {firstPlanet.EquatorLength}." +
                        $"\nЭквивалентна {planetToCompare.Name}: {isEqual}\n");

            isEqual = secondPlanet.Name == planetToCompare.Name
                        && secondPlanet.OrdinalNumberFromTheSun == planetToCompare.OrdinalNumberFromTheSun
                        && secondPlanet.EquatorLength == planetToCompare.EquatorLength ? "Да" : "Нет";
            sb.AppendLine($"Название: {secondPlanet.Name}, порядковый номер от Солнца: {secondPlanet.OrdinalNumberFromTheSun}, длина экватора: {secondPlanet.EquatorLength}, " +
                $"предыдущая планета: {secondPlanet.PreviousPlanet.Name}.\nЭквивалентна {planetToCompare.Name}: {isEqual}\n");

            isEqual = thirdPlanet.Name == planetToCompare.Name
                        && thirdPlanet.OrdinalNumberFromTheSun == planetToCompare.OrdinalNumberFromTheSun
                        && thirdPlanet.EquatorLength == planetToCompare.EquatorLength ? "Да" : "Нет";
            sb.AppendLine($"Название: {thirdPlanet.Name}, порядковый номер от Солнца: {thirdPlanet.OrdinalNumberFromTheSun}, длина экватора: {thirdPlanet.EquatorLength}, " +
                $"предыдущая планета: {thirdPlanet.PreviousPlanet.Name}.\nЭквивалентна {planetToCompare.Name}: {isEqual}\n");

            isEqual = fourthPlanet.Name == planetToCompare.Name
                        && fourthPlanet.OrdinalNumberFromTheSun == planetToCompare.OrdinalNumberFromTheSun
                        && fourthPlanet.EquatorLength == planetToCompare.EquatorLength ? "Да" : "Нет";
            sb.AppendLine($"Название: {fourthPlanet.Name}, порядковый номер от Солнца: {fourthPlanet.OrdinalNumberFromTheSun}, длина экватора: {fourthPlanet.EquatorLength}, " +
                $"предыдущая планета: {fourthPlanet.PreviousPlanet.Name}.\nЭквивалентна {planetToCompare.Name}: {isEqual}\n");

            Console.WriteLine(sb.ToString());
        }
    }
}