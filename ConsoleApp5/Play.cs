using System;

namespace ConsoleApp5
{
    internal class Play
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Play(string title, string author, string genre, int year)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public int GetAge() => DateTime.Now.Year - Year;

        public bool IsClassic() => GetAge() > 100;

        public void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Genre: {Genre}, Year: {Year}");
        }

        ~Play()
        {
            Console.WriteLine($"{Title} play has been destroyed: ");
        }
    }
}
