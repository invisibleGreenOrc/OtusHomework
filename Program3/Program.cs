using System.Text;

namespace Program3
{
    internal class Program
    {
        private const int _allowedNumberOfRequests = 2;

        static void Main()
        {
            var planets = new PlanetCatalog();

            var planetsToSearch = new List<string>
            {
                "Земля", "Лимония", "Марс"
            };

            var sb = new StringBuilder();
            
            var currentNumberOfRequests = 0;

            foreach (var planet in planetsToSearch)
            {
                var foundPlanet = planets.GetPlanet(planet, (name) =>
                {
                    currentNumberOfRequests++;

                    if (currentNumberOfRequests > _allowedNumberOfRequests)
                    {
                        currentNumberOfRequests = 0;
                        return "Вы спрашиваете слишком часто";
                    }

                    return null;
                });

                if (foundPlanet.Error is null)
                {
                    sb.AppendLine($"Название: {planet}, порядковый номер от Солнца: {foundPlanet.OrdinalNumberFromTheSun}, длина экватора: {foundPlanet.EquatorLength}\n");
                }
                else
                {
                    sb.AppendLine($"Планета {planet} не найдена. Ошибка: {foundPlanet.Error}\n");
                }
            }

            Console.WriteLine(sb.ToString());


            sb.Clear();

            foreach (var planet in planetsToSearch)
            {
                var foundPlanet = planets.GetPlanet(planet, (name) =>
                {
                    if (string.Equals(name, "Лимония"))
                    {
                        return "Это запретная планета";
                    }

                    return null;
                });

                if (foundPlanet.Error is null)
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