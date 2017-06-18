namespace _01.Sort_Times
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    public class SortTimes
    {
        static void Main()
        {
            var times = Console.ReadLine()
                .Split(' ');
            List<string> listOfTimes = new List<string>();
            foreach (var time in times)
            {
                DateTime date = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
                listOfTimes.Add(date.ToString("HH:mm"));
            }

            Console.WriteLine(string.Join(", ",listOfTimes.OrderBy(x=>x))); 
        }
    }
}
