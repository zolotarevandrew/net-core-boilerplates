namespace Algorithms.Comparers
{
    public struct CompareResult
    {
        CompareType _kind;

        public CompareResult(CompareType kind)
        {
            _kind = kind;
        }

        public bool IsEqual => _kind == CompareType.Equal;
        public bool IsFirstLess => _kind == CompareType.Less;
        public bool IsFirstMore => _kind == CompareType.More;
    }
}
