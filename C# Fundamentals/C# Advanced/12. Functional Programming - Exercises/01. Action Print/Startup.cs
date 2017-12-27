namespace _01.Action_Print
{
    using System;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            Action<string> PrintOnConsole = word=>Console.WriteLine(word);

            Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(PrintOnConsole);
        }
    }
}
