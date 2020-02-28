using System.Collections;

namespace Algorithms.Comparers
{
    public class IntComparer : IDataComparer<int>
    {
        public CompareResult Compare(int item1, int item2)
        {
            CompareType kind = CompareType.Equal;
            if (item1 == item2) kind = CompareType.Equal;
            if (item1 < item2) kind = CompareType.Less;
            if (item1 > item2) kind = CompareType.More;
            return new CompareResult(kind);
        }
    }
}
