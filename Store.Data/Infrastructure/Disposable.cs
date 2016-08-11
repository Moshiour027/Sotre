using System;

namespace Store.Data.Infrastructure
{
    public class Disposable : IDisposable
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

        //Override this to dispose custom objects
        /*
            This DisposeCore virtual method  will make other classes inherit this one, to dispose their own objects int he way they need to.
            Now add the implemetaion class ofthe IDbFactory interface
         */

        protected virtual void DisposeCore()
        {

        }
    }


    //DbFactory class already inherited by this class and Disposable class has implemented the method of IDisposable,
    //already and IDbFactory aslo inherit the inteface quality from the IDisposable so 

    //so inshort the extra method Init() if implemeted will make each of them happy
    public class DbFactory : Disposable, IDbFactory
    {
        StoreEntities dbContext;



        public StoreEntities Init()
        {
            return dbContext ?? (dbContext = new StoreEntities());
        }

        protected override void DisposeCore()
        {
            dbContext?.Dispose();
        }
    }
}
