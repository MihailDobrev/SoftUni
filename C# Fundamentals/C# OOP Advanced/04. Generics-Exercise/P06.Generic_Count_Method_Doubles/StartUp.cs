namespace P06.Generic_Count_Method_Doubles
{
    using P05.Generic_Count_Method_Strings;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<double> elements = GetElementsToCompare();
            CompareElements(elements);
        }

        private static void CompareElements(List<double> elements)
        {
            double comparingElement = double.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();
            Console.WriteLine(box.CountGreaterThan(elements, comparingElement));
        }

        private static List<double> GetElementsToCompare()
        {
            int numberOfItems = int.Parse(Console.ReadLine());
            List<double> elements = new List<double>();

            for (int i = 0; i < numberOfItems; i++)
            {
                elements.Add(double.Parse(Console.ReadLine()));
            }

            return elements;
        }
    }
}
