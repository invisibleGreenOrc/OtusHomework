namespace OtusHomework
{
    public static class LinqExtension
    {
        public static IEnumerable<T> Top<T>(this IEnumerable<T> enumerable, int percentage) where T : IComparable<T>
        {
            if (percentage < 1 || percentage > 100)
            {
                throw new ArgumentException($"{nameof(percentage)} вне диапазона [1, 100].");
            }

            var quantityToReturn = (int)Math.Ceiling((double)enumerable.Count() * percentage / 100);

            return enumerable.OrderByDescending(x => x).Take(quantityToReturn);
        }

        public static IEnumerable<T> Top<T>(this IEnumerable<T> enumerable, int percentage, Func<T, int> keyToSort)
        {
            if (percentage < 1 || percentage > 100)
            {
                throw new ArgumentException($"{nameof(percentage)} вне диапазона [1, 100].");
            }

            var quantityToReturn = (int)Math.Ceiling((double)enumerable.Count() * percentage / 100);

            return enumerable.OrderByDescending(keyToSort).Take(quantityToReturn);
        }
    }
}
