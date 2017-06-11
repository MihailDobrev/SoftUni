namespace _04.Grab_and_Go
{
    using System;
    using System.Linq;
    public class GrabandGo
    {
        static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int number = int.Parse(Console.ReadLine());

            int index = array.LastIndexOf(number);

            if (index<0)
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
                long sum = 0;

                for (int i = 0; i < index; i++)
                {
                    sum += array[i];
                }
                Console.WriteLine(sum);
            }
           
        }
    }
}
