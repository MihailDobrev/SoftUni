namespace _03.Group_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int>[] listOfNumbersInGroup = new List<int>[3];

            for (int index = 0; index < listOfNumbersInGroup.Length; index++)
            {
                listOfNumbersInGroup[index] = new List<int>();
            }
          
            foreach (int number in numbers)
            {
                int reminder = Math.Abs(number % 3);

                listOfNumbersInGroup[reminder].Add(number);
            }

            for (int row = 0; row < listOfNumbersInGroup.Length; row++)
            {
                for (int column = 0; column < listOfNumbersInGroup[row].Count; column++)
                {
                    Console.Write(listOfNumbersInGroup[row][column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
