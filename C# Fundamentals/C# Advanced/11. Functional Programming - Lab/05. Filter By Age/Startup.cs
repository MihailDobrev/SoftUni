namespace _05.Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            Dictionary<string, int> studentAges = new Dictionary<string, int>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] namesAndAges = Console.ReadLine()
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                studentAges.Add(namesAndAges[0], int.Parse(namesAndAges[1]));
            }

            string condition = Console.ReadLine();
            int yearToCheck = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Dictionary<string, int> orderedDictionary = new Dictionary<string, int>();

            switch (format)
            {
                case "name":
                    orderedDictionary = FilterBasedOnCondition(condition, studentAges, yearToCheck);
                    foreach (var pair in orderedDictionary)
                    {
                        Console.WriteLine(pair.Key);
                    }
                    break;

                case "age":
                    orderedDictionary = FilterBasedOnCondition(condition, studentAges, yearToCheck);
                    foreach (var pair in orderedDictionary)
                    {
                        Console.WriteLine(pair.Value);
                    }
                    break;
                case "name age":
                    orderedDictionary = FilterBasedOnCondition(condition, studentAges,yearToCheck);
                   
                    foreach (var pair in orderedDictionary)
                    {
                        Console.WriteLine($"{pair.Key} - {pair.Value}");
                    }
                    ; break;
                default:
                    break;
            }
        }

        public static Dictionary<string, int> FilterBasedOnCondition(string condition, Dictionary<string, int> studentAges, int yearToCheck)
        {
            Dictionary<string, int> orderedDictionary = new Dictionary<string, int>();

            if (condition == "younger")
            {
                orderedDictionary = studentAges.Where(x => x.Value < yearToCheck).ToDictionary(x => x.Key, y => y.Value);
            }
            else if (condition == "older")
            {
                orderedDictionary = studentAges.Where(x => x.Value >= yearToCheck).ToDictionary(x => x.Key, y => y.Value);
            }

            return orderedDictionary;
        }
    }
}
