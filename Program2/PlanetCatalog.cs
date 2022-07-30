namespace Program2
{
    public class PlanetCatalog
    {
        private List<Planet> _planets = new();
        private int _allowedNumberOfRequests;
        private int _currentNumberOfRequests;

        public PlanetCatalog()
        {
            _allowedNumberOfRequests = 2;
            _currentNumberOfRequests = 0;

            _planets.Add(new Planet("Венера", 2, 38025, _planets.LastOrDefault()));
            _planets.Add(new Planet("Земля", 3, 40076, _planets.LastOrDefault()));
            _planets.Add(new Planet("Марс", 4, 21296, _planets.LastOrDefault()));
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
