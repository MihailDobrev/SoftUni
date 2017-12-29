namespace _08.Map_Districts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            var districtInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            long minimumPopulation = long.Parse(Console.ReadLine());
            Dictionary<string, List<long>> populationRecords = new Dictionary<string, List<long>>();

            foreach (var singleDistrictInfo in districtInfo)
            {
                var splittedDistrictInfo = singleDistrictInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                string district = splittedDistrictInfo[0];
                long districtPopulation = long.Parse(splittedDistrictInfo[1]);

                if (!populationRecords.ContainsKey(district))
                {
                    populationRecords[district] = new List<long>();
                }

                populationRecords[district].Add(districtPopulation);

            }

            foreach (var pair in populationRecords.Where(x => x.Value.Sum() >= minimumPopulation).OrderByDescending(x => x.Value.Sum()))
            {
                Console.Write(pair.Key + ": ");
                Console.Write(string.Join(" ", pair.Value.OrderByDescending(x => x).Take(5)));
                Console.WriteLine();
            }
        }
    }
}
