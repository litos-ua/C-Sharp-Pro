using System;


namespace ConsoleApp5
{
    internal class SuccessorPlay : Play, IDisposable
    {
        private bool disposed = false;

        public SuccessorPlay(string title, string author, string genre, int year) : base(title, author, genre, year)
        {
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
                Console.WriteLine($"Releasing managed resources of play '{Title}'...");
            }

            Console.WriteLine($"Releasing unmanaged objects of play '{Title}'...");
            disposed = true;
        }

        ~SuccessorPlay()
        {
            Dispose(false);
            Console.WriteLine($"Play '{Title}' has been deleted.");
        }
    }
}

