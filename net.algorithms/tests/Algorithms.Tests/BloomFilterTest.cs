using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Hashing;

namespace Algorithms.Tests
{
    public class BloomFilterTest
    {
        [Fact]
        public void Test()
        {
            //Arrange
            int size = 1000000;
            var filter = new BloomFilter(size, 0.1);

            var fn = new Hash(new Fnv1a32());
            var fn1 = new Hash(new Murmur32());
            filter.AddHashFn(fn);
            filter.AddHashFn(fn1);

            //Act
            List<HashKey> res = new List<HashKey>(size);
            for(int i = 0; i < size; i++)
            {
                var item = new HashKey(i.ToString());
                res.Add(item);
                filter.Add(item);
            }

            //Assert
            for (int i = 0; i < size; i++)
            {
                Assert.True(filter.MayContains(res[i]));
            }
        }
    }
}
