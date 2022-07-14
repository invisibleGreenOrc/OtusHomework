namespace Program3
{
    public class Planet
    {
        public string Name { get; set; }
        public int OrdinalNumberFromTheSun { get; set; }
        public int EquatorLength { get; set; }
        public Planet? PreviousPlanet { get; set; }

        public Planet(string name, int ordinalNumberFromTheSun, int equatorLength, Planet? previousPlanet = null)
        {
            Name = name;
            OrdinalNumberFromTheSun = ordinalNumberFromTheSun;
            EquatorLength = equatorLength;
            PreviousPlanet = previousPlanet;
        }
    }
}
