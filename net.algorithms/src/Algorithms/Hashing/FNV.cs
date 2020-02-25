using System;

namespace Algorithms.Hashing
{
    public sealed class Fnv1a32 : System.Security.Cryptography.HashAlgorithm
    {
        private const uint FnvPrime = 0x01000193;
        private const uint FnvOffsetBasis = 0x811C9DC5;
        private uint _hash;

        public Fnv1a32()
        {
            Initialize();
            HashSizeValue = 32;
        }

        public override void Initialize() => _hash = FnvOffsetBasis;

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            for (int i = ibStart; i < cbSize; i++)
            {
                unchecked
                {
                    _hash ^= array[i];
                    _hash *= FnvPrime;
                }
            }
        }

        protected override byte[] HashFinal() => BitConverter.GetBytes(_hash);
    }
}
