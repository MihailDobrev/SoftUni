namespace _9.Count_the_Integ
{
    using System;
    public class CountTheIntegers
    {
        public static void Main()
        {
            string input;
            int counter = 0;
            bool result = true;
            int number = 0;

            while (result)
            {
                input = Console.ReadLine();

                result = int.TryParse(input, out number);
                if (result)
                {
                    counter++;
                }               
            }
            Console.WriteLine(counter);
        }
    }
}
