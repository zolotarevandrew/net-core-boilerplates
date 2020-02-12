using System;
using System.Threading;

namespace Concurrent.Schedulers
{
    public interface IResource
    {
        string Id { get; }
    }

    public interface IResourcePool<TResource> : IDisposable
        where TResource : IResource
    {
        TResource Get();
    }

    public class ResourcePool<TResource> : IResourcePool<TResource>
         where TResource : IResource
    {
        Semaphore _pool;

        public ResourcePool(int threadsCount)
        {
            _pool = new Semaphore(threadsCount, threadsCount);
        }

        public void Add(TResource resource)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _pool.Close();
        }

        public TResource Get()
        {
            throw new NotImplementedException();
        }
    }
}
