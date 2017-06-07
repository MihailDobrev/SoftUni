namespace Extract_Middle_1__2_or_3_Elements
{
    using System;
    using System.Linq;
    public class ExtractMiddleElements
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            if (array.Length == 1)
            {
                Console.WriteLine("{{ {0} }}", array[0]);
            }
            else if (array.Length % 2 == 0)
            {
                Console.WriteLine("{{ {0}, {1} }}",array[array.Length/2-1], array[array.Length / 2]);
            }
            else
            {
                Console.WriteLine("{{ {0}, {1}, {2} }}", array[array.Length / 2 - 1], array[array.Length / 2], array[array.Length / 2 + 1]);
            } 

        }
    }
}
