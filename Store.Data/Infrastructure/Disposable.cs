using System;

namespace Store.Data.Infrastructure
{
    class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }
        //this is the method that was implemeted to fulfil the interface requriement  another overlodading is supporting method to do this job
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {

        }
    }
}
