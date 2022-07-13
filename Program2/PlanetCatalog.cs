namespace Program2
{
    public class PlanetCatalog
    {
        private List<Planet> _planets = new();
        private int _allowedNumberOfRequests = 2;
        private int _currentNumberOfRequests = 0;

        public PlanetCatalog()
        {
            _planets.Add(new Planet("Венера", 38025, 2, _planets.LastOrDefault()));
            _planets.Add(new Planet("Земля", 40076, 3, _planets.LastOrDefault()));
            _planets.Add(new Planet("Марс", 21296, 4, _planets.LastOrDefault()));
        }

        public (int OrdinalNumberFromTheSun, int EquatorLength, string Error) GetPlanet(string name)
        {
            _currentNumberOfRequests++;

            (int OrdinalNumberFromTheSun, int EquatorLength, string Error) output;

            if (_currentNumberOfRequests > _allowedNumberOfRequests)
            {
                _currentNumberOfRequests = 0;
                output = (0, 0, "Вы спрашиваете слишком часто");
                return output;
            }

            var foundPlanet = _planets.Find(x => string.Equals(x.Name, name));
            
            if (foundPlanet is null)
            {
                output = (0, 0, "Не удалось найти планету");
                return output;
            }

            output = (foundPlanet.OrdinalNumberFromTheSun, foundPlanet.EquatorLength, string.Empty);

            return output;
        }
    }
}
