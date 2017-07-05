namespace _04.Weather
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class Weather
    {
        static void Main()
        {
            string pattern = @"([A-Z]{2})(\d+.\d+)([A-Za-z]+)(?:\|)";
            string input;
            Dictionary<string, City> cities = new Dictionary<string, City>();

            while ((input = Console.ReadLine()) != "end")
            {
                var regex = Regex.Match(input, pattern);

                if (regex.Success)
                {
                    string name = regex.Groups[1].Value;
                    double averageTemperature = double.Parse(regex.Groups[2].Value);
                    string weatherType = regex.Groups[3].Value;
                    City city = new City()
                    {
                        Name = name,
                        AverageTemperature = averageTemperature,
                        WeatherType = weatherType
                    };
                    cities[name] = city;
                }
            }

            foreach (var city in cities.OrderBy(x => x.Value.AverageTemperature))
            {
                Console.WriteLine($"{city.Value.Name} => {city.Value.AverageTemperature:F2} => {city.Value.WeatherType}");
            }
        }
    }

}
