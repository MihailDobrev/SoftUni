
namespace _5.Foreign_Languages
{
    using System;
    using System.Collections.Generic;
    public class ForeignLanguages
    {
        static void Main()
        {
            var countriesLanguages = new Dictionary<string, string>();
            countriesLanguages.Add("USA", "English");
            countriesLanguages.Add("England", "English");
            countriesLanguages.Add("Spain", "Spanish");
            countriesLanguages.Add("Argentina", "Spanish");
            countriesLanguages.Add("Mexico", "Spanish");

            var nameOfCountry = Console.ReadLine();

            if (countriesLanguages.ContainsKey(nameOfCountry))
            {
                Console.WriteLine(countriesLanguages[nameOfCountry]);
            }
            else
            {
                Console.WriteLine("unknown");
            }

        }
    }
}
