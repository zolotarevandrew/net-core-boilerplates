namespace Algorithms.Extensions
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] a, int i1, int i2)
        {
            T t = a[i1];
            a[i1] = a[i2];
            a[i2] = t;
        }
    }
}
