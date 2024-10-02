using System;

namespace ConsoleApp4
{
    public class City
    {
        private string? cityName;
        private string? country;
        private int population;
        private long budget;

        public string CityName
        {
            get { return cityName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("City name cannot be empty.");
                }
                cityName = value;
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Country cannot be empty.");
                }
                country = value;
            }
        }

        public int Population
        {
            get { return population; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Population cannot be negative.");
                }
                population = value;
            }
        }

        public long Budget
        {
            get { return budget; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Budget cannot be negative.");
                }
                budget = value;
            }
        }

        public City(string cityName, string country, int population, long budget)
        {
            CityName = cityName;
            Country = country;
            Population = population;
            Budget = budget;
        }

        public static City operator +(City city, int increase)
        {
            city.Population += increase;
            return city;
        }

        public static City operator -(City city, int decrease)
        {
            city.Population -= decrease;
            if (city.Population < 0)
            {
                city.Population = 0; // Численность не может быть меньше нуля
            }
            return city;
        }

        public static bool operator ==(City city1, City city2)
        {
            return city1.Population == city2.Population;
        }

        public static bool operator !=(City city1, City city2)
        {
            return !(city1 == city2);
        }

        public static bool operator <(City city1, City city2)
        {
            return city1.Population < city2.Population;
        }

        public static bool operator >(City city1, City city2)
        {
            return city1.Population > city2.Population;
        }

        public override bool Equals(object? obj)
        {
            if (obj is City city)
            {
                return Population == city.Population;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Population.GetHashCode();
        }

        public override string ToString()
        {
            return $"City: {CityName}, Country: {Country}, Population: {Population}, Budget: {Budget} USD";
        }
    }

}

