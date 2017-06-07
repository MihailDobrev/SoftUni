namespace Triple_Sum
{
    using System;
    using System.Linq;
    public class TripleSum
    {
        static void Main()
        {

            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(m => Convert.ToInt32(m))
                .ToArray();
                 

            bool tripleExists = false;

            for (int a = 0; a < numbers.Length; a++)
            {
                for (int b = a + 1; b < numbers.Length; b++)
                {
                    for (int c = 0; c < numbers.Length; c++)
                    {
                        if (numbers[a] + numbers[b] == numbers[c])
                        {
                            tripleExists = true;
                            Console.WriteLine($"{numbers[a]} + {numbers[b]} == {numbers[c]}");
                            break;
                        }

                    }
                }

            }
            if (!tripleExists)
            {
                Console.WriteLine("No");
            }
        }

    }

}
