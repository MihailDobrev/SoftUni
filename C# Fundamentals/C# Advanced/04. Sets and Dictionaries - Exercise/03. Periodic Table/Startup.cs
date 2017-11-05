namespace _03.Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int numberOfElements = int.Parse(Console.ReadLine());

            HashSet<string> uniqueElements = new HashSet<string>();

            for (int i = 0; i < numberOfElements; i++)
            {
                string[] chemicalElementsInput = Console.ReadLine().Split();

                foreach (var element in chemicalElementsInput)
                {
                    uniqueElements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ",uniqueElements.OrderBy(el=>el)));
        }
    }
}
