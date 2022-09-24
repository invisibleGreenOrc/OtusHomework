using System.Collections.Concurrent;
using System.Text;

namespace Librarian
{
    internal class Repository
    {
        public ConcurrentDictionary<string, int> Storage { get; } = new();

        private readonly int _updateDelay = 1000;
        private readonly int _updateIncrement = 1;
        private readonly int _maxValue = 100;
        private readonly int _defaultValue = 0;

        public Repository()
        {
            Task.Run(UpdateValues);
        }

        public void Add(string key)
        {
            ArgumentNullException.ThrowIfNull(key);

            Storage.TryAdd(key, _defaultValue);
        }

        public override string ToString()
        {
            if (Storage.IsEmpty)
            {
                return "Хранилище пустое.\n";
            }

            var sb = new StringBuilder();

            foreach (var item in Storage)
            {
                sb.AppendLine($"{item.Key} - {item.Value}%");
            }

            return sb.ToString();
        }

        private async Task UpdateValues()
        {
            while (true)
            {
                foreach (var item in Storage)
                {
                    if (item.Value == (_maxValue - _updateIncrement))
                    {
                        Storage.TryRemove(item);
                    }
                    else
                    {
                        Storage[item.Key] = item.Value + _updateIncrement;
                    }
                }

                await Task.Delay(_updateDelay);
            }
        }
    }
}
