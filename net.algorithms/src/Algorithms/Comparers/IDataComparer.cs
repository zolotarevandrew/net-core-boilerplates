namespace Algorithms.Comparers
{
    public interface IDataComparer<T>
    {
        CompareResult Compare(T item1, T item2);
    }
}    
