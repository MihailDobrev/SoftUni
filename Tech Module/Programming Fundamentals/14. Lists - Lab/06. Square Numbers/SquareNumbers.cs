namespace _6.Square_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class SquareNumbers
    {
        static void Main()
        {
            var list = Console.ReadLine()
                .Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var squareNumbers = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (Math.Sqrt(list[i]) % 1 == 0)
                {
                    squareNumbers.Add(list[i]);
                }
            }
            squareNumbers.Sort();
            squareNumbers.Reverse();

            foreach (var number in squareNumbers)
            {
                Console.Write(number+" ");
            }
        }
    }
}
