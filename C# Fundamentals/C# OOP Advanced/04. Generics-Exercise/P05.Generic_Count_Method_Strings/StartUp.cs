using System;
using System.Collections.Generic;

namespace P05.Generic_Count_Method_Strings
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> elements = GetElementsToCompare();
            CompareElements(elements);
        }

        private static void CompareElements(List<string> elements)
        {
            string comparingElement = Console.ReadLine();
            Box<string> box = new Box<string>();
            Console.WriteLine(box.CountGreaterThan(elements, comparingElement));
        }

        private static List<string> GetElementsToCompare()
        {
            int numberOfItems = int.Parse(Console.ReadLine());
            List<string> elements = new List<string>();

            for (int i = 0; i < numberOfItems; i++)
            {
                elements.Add(Console.ReadLine());
            }

            return elements;
        }
    }
}
