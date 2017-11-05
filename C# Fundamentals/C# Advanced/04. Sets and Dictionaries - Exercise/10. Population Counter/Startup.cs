namespace _10.Population_Counter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input;
            Dictionary<string, Dictionary<string, long>> populationRecords = new Dictionary<string, Dictionary<string, long>>();
            input = Console.ReadLine();

            while (input!="report")
            {
                string[] populationData = input.Split('|');

                string city = populationData[0];
                string country = populationData[1];
                long population = long.Parse(populationData[2]);

                if (!populationRecords.ContainsKey(country))
                {
                    populationRecords[country] = new Dictionary<string, long>();
                }

                if (!populationRecords[country].ContainsKey(city))
                {
                    populationRecords[country][city] = population;
                }
                else
                {
                    populationRecords[country][city] += population;
                }
                

                input = Console.ReadLine();
            }

            foreach (var recordPair in populationRecords.OrderByDescending(p=>p.Value.Values.Sum()))
            {
                Console.WriteLine($"{recordPair.Key} (total population: {recordPair.Value.Values.Sum()})");

                var cityData = recordPair.Value;

                foreach (var pair in cityData.OrderByDescending(c=>c.Value))
                {
                    Console.WriteLine($"=>{pair.Key}: {pair.Value}");
                }
            }
        }
    }
}
