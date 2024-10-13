using System;

namespace ConsoleApp5
{
    public class Store : IDisposable
    {
        public string StoreName { get; set; }
        public string Address { get; set; }
        public string StoreType { get; set; } 
        public bool IsOpen { get; private set; }
        private bool disposed = false;

        public Store(string storeName, string address, string storeType)
        {
            StoreName = storeName;
            Address = address;
            StoreType = storeType;
            IsOpen = false; 
        }

        public void OpenStore()
        {
            if (!IsOpen)
            {
                IsOpen = true;
                Console.WriteLine($"Store '{StoreName}' is now open.");
            }
            else
            {
                Console.WriteLine($"Store '{StoreName}' is already open.");
            }
        }

        public void CloseStore()
        {
            if (IsOpen)
            {
                IsOpen = false;
                Console.WriteLine($"Store '{StoreName}' is now closed.");
            }
            else
            {
                Console.WriteLine($"Store '{StoreName}' is already closed.");
            }
        }

        public void ServeCustomer(string customerName)
        {
            if (IsOpen)
            {
                Console.WriteLine($"Serving customer {customerName} at '{StoreName}'.");
            }
            else
            {
                Console.WriteLine($"Sorry, '{StoreName}' is closed. Cannot serve customer {customerName}.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
   
            if (disposing)
                {
                    Console.WriteLine($"Releasing managed resources of store '{StoreName}'...");
                }

                Console.WriteLine($"Releasing unmanaged objects of store '{StoreName}'...");
                disposed = true;
        }
    }
}
