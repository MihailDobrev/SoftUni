

namespace _03.Sum_Adjacent_Equal_Numbers
{
    using System;
    using System.Linq;

    public class SumAdjacentEqualNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                      .Split(' ')
                      .Select(double.Parse)
                      .ToList();

            int index = 1;

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        for (index = 1; index < numbers.Count; index++)
                        {
                            if (numbers[index - 1] == numbers[index])
                            {
                                numbers[index - 1] = numbers[index - 1] + numbers[index];
                                numbers.RemoveAt(index);
                            }
                        }
                        index = 1;
                    }
                }

            }

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
