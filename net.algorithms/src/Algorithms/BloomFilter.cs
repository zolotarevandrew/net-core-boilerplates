using Algorithms.Hashing;
using System;
using System.Collections;

namespace Algorithms
{
    public class BloomFilter
    {
        BitArray _bitArray;
        IHash[] _hashFunctions;
        int _hashFnCount;

        public BloomFilter(long size, double falsePositiveRate)
        {
            Size = size;
            FPRate = falsePositiveRate;
            M = GetM(Size, FPRate);
            K = GetK(Size, M);

            _hashFnCount = 0;
            _bitArray = new BitArray((int)M);
            _hashFunctions = new IHash[K];
        }

        public long Size { get; }
        public double FPRate { get; }
        public uint K { get; }
        public uint M { get; }

        public void AddHashFn(IHash function)
        {
            int length = _hashFnCount;
            if (length < K)
            {
                _hashFunctions[length] = function;
                _hashFnCount++;
            }
        }

        public void Add(HashKey key)
        {
            CheckAllHashFnInitialized();
            for (int idx = 0; idx < _hashFunctions.Length; idx++)
            {
                var hashIdx = (int)(_hashFunctions[idx].Compute(key) % M);
                _bitArray.Set(hashIdx, true);
            }
        }

        public bool MayContains(HashKey key)
        {
            CheckAllHashFnInitialized();
            for (int idx = 0; idx < _hashFunctions.Length; idx++)
            {
                var hashIdx = (int)(_hashFunctions[idx].Compute(key) % M);
                if (!_bitArray.Get(hashIdx)) return false;
            }
            return true;
        }

        void CheckAllHashFnInitialized()
        {
            if (_hashFunctions.Length != K)
                throw new InvalidOperationException("Please add more Hash functions!");
        }

        uint GetM(long size, double fpRate)
        {
            var m = -(size * Math.Log(fpRate)) / (Math.Log(2) * Math.Log(2));
            return (uint)m;
        }

        uint GetK(long size, uint m)
        {
            var res = (m / size) * Math.Log(2);
            return (uint)res;
        }
    }
}
