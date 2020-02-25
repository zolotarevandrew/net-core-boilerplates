using System.Text;

namespace Algorithms.Hashing
{
    public struct HashKey
    {
        byte[] bytes;
        public HashKey(string var3)
        {
            bytes = Encoding.ASCII.GetBytes(var3);
        }

        public byte[] ToBytes()
        {
            return bytes;
        }
    }
}
