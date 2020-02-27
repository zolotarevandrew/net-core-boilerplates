using Algorithms.Extensions;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class SearchTreeSimple<T>
    {
        T _value;
        bool _hasValue;

        SearchTreeSimple<T> _left = null;
        SearchTreeSimple<T> _right = null;

        Func<T, T, EqualityKind> _equalityComparer;

        public SearchTreeSimple(Func<T, T, EqualityKind> equalityComparer)
        {
            _equalityComparer = equalityComparer;
        }

        public SearchTreeSimple<T> Add(T item)
        {
            return Add(this, item);
        }

        public SearchTreeSimple<T> Search(T item)
        {
            SearchTreeSimple<T> Search(SearchTreeSimple<T> node, T it)
            {
                if (node == null) return null;

                var equality = _equalityComparer(node._value, it);
                if (equality == EqualityKind.Equal) return node;

                if (equality == EqualityKind.Less) return Search(node._left, it);
                if (equality == EqualityKind.More) return Search(node._right, it);
                return null;
            }
            return Search(this, item);
        }

        public IEnumerable<T> InOrder()
        {
            IEnumerable<T> InOrder(SearchTreeSimple<T> node)
            {
                if (node != null)
                {
                    foreach (var it in InOrder(node._left)) yield return it;
                    yield return node._value;
                    foreach (var it in InOrder(node._right)) yield return it;
                }
            }
            return InOrder(this);
        }

        SearchTreeSimple<T> Add(SearchTreeSimple<T> node, T item)
        {
            if (!node._hasValue)
            {
                SetValue(item);
                return node;
            }

            var equality = _equalityComparer(node._value, item);

            if (equality == EqualityKind.Less)
            {
                return TryAddItem(ref node._left, item);
            }
            if (equality == EqualityKind.More)
            {
                return TryAddItem(ref node._right, item);
            }
            return node;
        }

        SearchTreeSimple<T> TryAddItem(ref SearchTreeSimple<T> node, T item)
        {
            if (node == null)
            {
                node = new SearchTreeSimple<T>(_equalityComparer);
                node.SetValue(item);
                return node;
            }
            return Add(node, item);
        }

        void SetValue(T item)
        {
            _value = item;
            _hasValue = true;
        }
    }
}
