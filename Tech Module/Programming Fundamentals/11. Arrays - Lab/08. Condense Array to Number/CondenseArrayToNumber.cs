namespace Condense_Array_to_Number
{
    using System;
    using System.Linq;
    public class CondenseArrayToNumber
    {
        static void Main()
        {
            int[] array = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

            int[] condensed = new int[array.Length - 1];

            int i = 0;

            while (array[i] > 1)
            {
                for (i = 0; i < array.Length - 1; i++)
                {
                    condensed[i] = array[i] + array[i + 1];
                    array[i] = condensed[i];
                }

            }

            foreach (var item in condensed)
            {
                Console.WriteLine(item);
            }
        }
    }
}
