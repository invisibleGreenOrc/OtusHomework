namespace Program3
{
    public class PlanetCatalog
    {
        public delegate string? PlanetValidator(string name);

        private List<Planet> _planets = new();

        public PlanetCatalog()
        {
            _planets.Add(new Planet("Венера", 2, 38025, _planets.LastOrDefault()));
            _planets.Add(new Planet("Земля", 3, 40076, _planets.LastOrDefault()));
            _planets.Add(new Planet("Марс", 4, 21296, _planets.LastOrDefault()));
        }

        public (int OrdinalNumberFromTheSun, int EquatorLength, string? Error) GetPlanet(string name, PlanetValidator planetValidator)
        {
            (int OrdinalNumberFromTheSun, int EquatorLength, string? Error) output;

            var checkResult = planetValidator(name);

            if (checkResult is not null)
            {
                output = (0, 0, checkResult);
                return output;
            }

            var foundPlanet = _planets.Find(x => string.Equals(x.Name, name));
            
            if (foundPlanet is null)
            {
                output = (0, 0, "Не удалось найти планету");
                return output;
            }

            output = (foundPlanet.OrdinalNumberFromTheSun, foundPlanet.EquatorLength, null);

            return output;
        }
    }
}
