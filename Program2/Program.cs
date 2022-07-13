using System.Text;

namespace Program2
{
    internal class Program
    {
        static void Main()
        {
            var planets = new PlanetCatalog();

            var planetsToSearch = new List<string>
            {
                "Земля", "Лимония", "Марс"
            };

            var sb = new StringBuilder();

            foreach (var planet in planetsToSearch)
            {
                var foundPlanet = planets.GetPlanet(planet);

                if (string.Equals(foundPlanet.Error, string.Empty))
                {
                    sb.AppendLine($"Название: {planet}, порядковый номер от Солнца: {foundPlanet.OrdinalNumberFromTheSun}, длина экватора: {foundPlanet.EquatorLength}\n");
                }
                else
                {
                    sb.AppendLine($"Планета {planet} не найдена. Ошибка: {foundPlanet.Error}\n");
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}