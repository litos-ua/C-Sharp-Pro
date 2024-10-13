using System;

namespace ConsoleApp5
{
    public class SuccessorStore : Store
    {
        private bool IsDisposed = false;

        public SuccessorStore(string storeName, string address, string storeType) : base(storeName, address, storeType)
        {
        }

        ~SuccessorStore()
        {
            Dispose(false);
            Console.WriteLine($"Store '{StoreName}' has been destroyed.");
        }

        protected override void Dispose(bool disposing)
        {
            if (IsDisposed) return;

            IsDisposed = true;

            base.Dispose(disposing);
            
        }
    }
}


