using System.Collections.Immutable;

namespace JackHouse
{
    internal class Part
    {
        public ImmutableList<string> Poem { get; private set; } = ImmutableList<string>.Empty;

        private List<string> _stringsToAdd;

        public Part(List<string> strings)
        {
            ArgumentNullException.ThrowIfNull(strings, nameof(strings));

            _stringsToAdd = strings;
        }

        public void AddPart(ImmutableList<string> poem)
        {
            ArgumentNullException.ThrowIfNull(poem, nameof(poem));

            Poem = poem.AddRange(_stringsToAdd);
        }
    }
}
