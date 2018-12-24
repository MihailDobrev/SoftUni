namespace Linear_Data_Structures___Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> numbers = ReadNumbers();
            PrintToConsole(numbers);
        }

        private static void PrintToConsole(List<int> numbers)
        {
            if (numbers.Count>0)
            {
                var average = (decimal)numbers.Sum() / numbers.Count;
                Console.WriteLine($"Sum={numbers.Sum()}; Average={average:f2}");
            }
            else
            {
                var num = 0;
                Console.WriteLine($"Sum=0; Average={num:F2}");
            }
           
        }

        private static List<int> ReadNumbers()
        {
            List<int> list = new List<int>();

            string input = Console.ReadLine();

            if (!String.IsNullOrEmpty(input) || !string.IsNullOrWhiteSpace(input))
            {
                var splitedInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var part in splitedInput)
                {
                    var isNum = int.TryParse(part, out int number);
                    if (isNum)
                    {
                        list.Add(number);
                    }
                }

                return list;
            }
            else
            {
                return null;
            }
                            
        }
    }
}
