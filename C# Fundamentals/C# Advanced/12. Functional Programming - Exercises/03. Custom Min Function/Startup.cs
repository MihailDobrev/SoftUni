namespace _03.Custom_Min_Function
{
    using System;
    using System.Linq;
    public class Startup
    {
        static void Main()
        {            
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int[], int> getLowestNumber = x => x.Min();
            Console.WriteLine(getLowestNumber(numbers));
        }
    }
}
