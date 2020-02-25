using System;
using System.Security.Cryptography;

namespace Algorithms.Hashing
{
    internal static class MurmurExtensions
    {
        internal static uint ToUInt32(this byte[] data, int start)
        {
            return BitConverter.IsLittleEndian
                    ? (uint)(data[start] | data[start + 1] << 8 | data[start + 2] << 16 | data[start + 3] << 24)
                    : (uint)(data[start] << 24 | data[start + 1] << 16 | data[start + 2] << 8 | data[start + 3]);
        }

        internal static ulong ToUInt64(this byte[] data, int start)
        {
            if (BitConverter.IsLittleEndian)
            {
                uint i1 = (uint)(data[start] | data[start + 1] << 8 | data[start + 2] << 16 | data[start + 3] << 24);
                ulong i2 = (ulong)(data[start + 4] | data[start + 5] << 8 | data[start + 6] << 16 | data[start + 7] << 24);
                return (i1 | i2 << 32);
            }
            else
            {
                ulong i1 = (ulong)(data[start] << 24 | data[start + 1] << 16 | data[start + 2] << 8 | data[start + 3]);
                uint i2 = (uint)(data[start + 4] << 24 | data[start + 5] << 16 | data[start + 6] << 8 | data[start + 7]);
                return (i2 | i1 << 32);

                //int i1 = (*pbyte << 24) | (*(pbyte + 1) << 16) | (*(pbyte + 2) << 8) | (*(pbyte + 3));
                //int i2 = (*(pbyte + 4) << 24) | (*(pbyte + 5) << 16) | (*(pbyte + 6) << 8) | (*(pbyte + 7));
                //return (uint)i2 | ((long)i1 << 32);
            }
        }

        internal static uint RotateLeft(this uint x, byte r)
        {
            return (x << r) | (x >> (32 - r));
        }

        internal static ulong RotateLeft(this ulong x, byte r)
        {
            return (x << r) | (x >> (64 - r));
        }

        internal static uint FMix(this uint h)
        {
            // pipelining friendly algorithm
            h = (h ^ (h >> 16)) * 0x85ebca6b;
            h = (h ^ (h >> 13)) * 0xc2b2ae35;
            return h ^ (h >> 16);
        }

        internal static ulong FMix(this ulong h)
        {
            // pipelining friendly algorithm
            h = (h ^ (h >> 33)) * 0xff51afd7ed558ccd;
            h = (h ^ (h >> 33)) * 0xc4ceb9fe1a85ec53;

            return (h ^ (h >> 33));
        }
    }

    public class Murmur32 : Murmur32Base
    {
        public Murmur32(uint seed = 0)
            : base(seed)
        {
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            Length += cbSize;
            Body(array, ibStart, cbSize);
        }

        private void Body(byte[] data, int start, int length)
        {
            int remainder = length & 3;
            int alignedLength = start + (length - remainder);

            for (int i = start; i < alignedLength; i += 4)
                H1 = (((H1 ^ (((data.ToUInt32(i) * C1).RotateLeft(15)) * C2)).RotateLeft(13)) * 5) + 0xe6546b64;

            if (remainder > 0)
                Tail(data, alignedLength, remainder);
        }

        private void Tail(byte[] tail, int position, int remainder)
        {
            // create our keys and initialize to 0
            uint k1 = 0;

            // determine how many bytes we have left to work with based on length
            switch (remainder)
            {
                case 3: k1 ^= (uint)tail[position + 2] << 16; goto case 2;
                case 2: k1 ^= (uint)tail[position + 1] << 8; goto case 1;
                case 1: k1 ^= tail[position]; break;
            }

            H1 ^= (k1 * C1).RotateLeft(15) * C2;
        }

        internal static uint ToUInt32(byte[] data, int start)
        {
            return BitConverter.IsLittleEndian
                    ? (uint)(data[start] | data[start + 1] << 8 | data[start + 2] << 16 | data[start + 3] << 24)
                    : (uint)(data[start] << 24 | data[start + 1] << 16 | data[start + 2] << 8 | data[start + 3]);
        }

    }

    public abstract class Murmur32Base : HashAlgorithm
    {
        protected const uint C1 = 0xcc9e2d51;
        protected const uint C2 = 0x1b873593;

        readonly uint _Seed;

        protected Murmur32Base(uint seed)
        {
            _Seed = seed;
            Reset();
        }

        public override int HashSize { get { return 32; } }
        public uint Seed { get { return _Seed; } }

        protected uint H1 { get; set; }

        protected int Length { get; set; }

        private void Reset()
        {
            H1 = Seed;
            Length = 0;
        }

        public override void Initialize()
        {
            Reset();
        }

        protected override byte[] HashFinal()
        {
            H1 = (H1 ^ ((uint)Length).FMix());

            return BitConverter.GetBytes(H1);
        }

        static uint FMix(uint h)
        {
            // pipelining friendly algorithm
            h = (h ^ (h >> 16)) * 0x85ebca6b;
            h = (h ^ (h >> 13)) * 0xc2b2ae35;
            return h ^ (h >> 16);
        }
    }
}
