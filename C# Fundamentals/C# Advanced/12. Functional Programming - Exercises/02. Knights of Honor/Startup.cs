namespace _02.Knights_of_Honor
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Action<string> AppendSirAndPrint = x => Console.WriteLine($"Sir {x}");

            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(AppendSirAndPrint);
        }
    }
}
