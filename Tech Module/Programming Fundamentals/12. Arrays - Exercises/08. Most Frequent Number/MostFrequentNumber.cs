namespace Most_Frequent_Number
{
    using System;
    using System.Linq;
    public class MostFrequentNumber
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();


            int repetitions = 0;

            int mostFrequentNumber = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int counter = 0;

                for (int j = i; j < numbers.Length; j++)
                {
                    if (currentNumber == numbers[j])
                    {
                        counter++;
                    }
                }
                if (counter > repetitions)
                {
                    mostFrequentNumber = currentNumber;
                    repetitions = counter;
                }
            }
            Console.WriteLine(mostFrequentNumber);
        }
    }
}
