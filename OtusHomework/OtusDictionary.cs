namespace OtusHomework
{
    internal class OtusDictionary
    {
        private Item[] _storage;
        private int _storageLength;

        public string this[int key]
        {
            get => Get(key);
            set => Add(key, value);
        }

        public OtusDictionary()
        {
            _storage = new Item[32];
            _storageLength = _storage.Length;
        }

        public void Add(int key, string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            var hash = GetHash(key);

            var item = _storage[hash];

            if (item is null)
            {
                _storage[hash] = new Item(key, value);
            }
            else if (item.Key == key)
            {
                throw new ArgumentException($"Элемент с ключом {key} уже добавлен.");
            }
            else
            {
                IncreaseStorage();
                Add(key, value);
            }
        }

        public string Get(int key)
        {
            var hash = GetHash(key);

            if (_storage[hash]?.Key == key)
            {
                return _storage[hash].Value;
            }

            throw new ArgumentException($"Элемент с ключом {key} не найден.");
        }

        private int GetHash(int value)
        {
            return value % _storageLength;
        }

        private void IncreaseStorage()
        {
            var currentLength = _storage.Length;
            _storageLength = 2 * currentLength;
            var newStorage = new Item[_storageLength];

            for (int i = 0; i < currentLength; i++)
            {
                if (_storage[i] is not null)
                {
                    newStorage[GetHash(_storage[i].Key)] = _storage[i];
                }
            }

            _storage = newStorage;
        }
    }
}
