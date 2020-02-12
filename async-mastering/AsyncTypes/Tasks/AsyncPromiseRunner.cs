using AsyncTypes.Tasks;
using Promises.Entities;
using System;

namespace Promises.Tasks
{
    /*
    public class AsyncPromiseRunner<T>
    {
        readonly Func<AsyncPromise<T>> _run;
        AsyncPromise<T> _task;

        public AsyncPromiseRunner(Func<AsyncPromise<T>> run)
        {
            _run = run;
        }

        public PromiseResult<T> Run()
        {
            if (_task?.Promise != null)
            {
                var promise = _task.Promise;
                promise.Run();
                if (_task.Status == PromiseStatus.InProgress)
                    return new PromiseResult<T>(PromiseStatus.InProgress);
            }
            if (_task == null)
                _task = _run();
            else
                _task.Continue();
            if (_task.IsCompleted)
                return _task.Promise.Result;

            if (_task.Promise == null)
                return new PromiseResult<T>(PromiseStatus.InProgress);
            return new PromiseResult<T>(PromiseStatus.InProgress);
        }
    }
    */
}
