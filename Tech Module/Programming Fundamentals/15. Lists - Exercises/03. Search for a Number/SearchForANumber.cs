namespace _03.Search_for_a_Number
{
    using System;
    using System.Linq;

    public class SearchForANumber
    {
        static void Main()
        {
            var integerList = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var threeNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var newArray = integerList
                .Take(threeNumbers[0])
                .ToList()
                .Skip(threeNumbers[1])
                .ToList();

            if (newArray.Exists(x=>x==threeNumbers[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
