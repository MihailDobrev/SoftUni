namespace _14.Cat_Lady
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<Cat> cats = new List<Cat>();

            while (input != "End")
            {
                string[] catInfo = input.Split();
                string catType = catInfo[0];
                string catName = catInfo[1];

                switch (catType)
                {
                    case "Siamese":
                        int earSize = int.Parse(catInfo[2]);
                        Siamese siamese = new Siamese(catType, catName, earSize);
                        cats.Add(siamese);
                        break;
                    case "Cymric":
                        double furLength = double.Parse(catInfo[2]);
                        Cymric cymric = new Cymric(catType, catName, furLength);
                        cats.Add(cymric);
                        break;
                    case "StreetExtraordinaire":
                        int decibelsOfMewows = int.Parse(catInfo[2]);
                        StreetExtraordinaire streetExtraordinaire = new StreetExtraordinaire(catType, catName, decibelsOfMewows);
                        cats.Add(streetExtraordinaire);
                        break;
                    default:
                        break;

                }

                input = Console.ReadLine();
            }

            string catNameToFind = Console.ReadLine();

            var catFound = cats.Where(c => c.Name == catNameToFind).First();

            Console.WriteLine(catFound.ToString());
        }
    }
}
