namespace _07.Bomb_Numbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class BombNumbers
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToList();
            List<int> specialNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int specialNumber = specialNumbers[0];
            int power = specialNumbers[1];
            int sum = 0;

            for (int index = 0; index < numbers.Count; index++)
            {
                if (specialNumber==numbers[index])
                {
                    try
                    {
                        numbers.RemoveRange(index, power + 1);
                        
                    }
                    catch (ArgumentException)
                    {
                        numbers.RemoveRange(index, numbers.Count - index);
                    }
                    try
                    {
                        numbers.RemoveRange(index - power, power);
                    }
                    catch (ArgumentException)
                    {
                        numbers.RemoveRange(0, index-0);
                    }
                    index = 0;
                }
            }           

            foreach (var number in numbers)
            {
                sum += number;
            }
            Console.WriteLine(sum);

        }
    }
}
