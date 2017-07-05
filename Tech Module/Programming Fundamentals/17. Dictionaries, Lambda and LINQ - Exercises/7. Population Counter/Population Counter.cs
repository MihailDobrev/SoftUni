
namespace _7.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PopulationCounter
    {
        static void Main()
        {
            string input;
            var countries = new Dictionary<string, Dictionary<string, long>>();

            while ((input = Console.ReadLine()) != "report")
            {
                var populationInfo = input.Split('|');
                string country = populationInfo[1];
                string city = populationInfo[0];
                long population = long.Parse(populationInfo[2]);

                if (!countries.ContainsKey(country))
                {
                    countries[country] = new Dictionary<string, long>();
                }

                if (!countries[country].ContainsKey(city))
                {
                    countries[country][city] = 0;
                }
                countries[country][city] += population;
            }

            var orderedCountries = countries
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(y => y.Key, y => y.Value);

            foreach (var country in orderedCountries)
            {
                var countryName = country.Key;
                var cityInfo = country.Value
                    .OrderByDescending(x => x.Value)
                    .ToDictionary(y => y.Key, y => y.Value);

                var totalPopulation = cityInfo.Values.Sum();

                Console.WriteLine($"{countryName} (total population: {totalPopulation})");

                foreach (var pair in cityInfo)
                {
                    var city = pair.Key;
                    var population = pair.Value;
                    Console.WriteLine($"=>{city}: {population}");
                }
            }
        }
    }
}
