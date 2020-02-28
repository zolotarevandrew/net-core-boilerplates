namespace Algorithms.Comparers
{
    public static class DataComparers
    {
        public static IDataComparer<int> Int = new IntComparer();

        public static IDataComparer<T> ByType<T>()
        {
            if (typeof(T) == typeof(int))
            {
                return Int as IDataComparer<T>;
            }
            return null;
        }

        public static IDataComparer<T> NewByType<T>()
        {
            if (typeof(T) == typeof(int))
            {
                return new IntComparer() as IDataComparer<T>;
            }
            return null;
        }
    }
}
