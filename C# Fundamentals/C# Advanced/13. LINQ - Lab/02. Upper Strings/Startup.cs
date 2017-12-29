namespace _02.Upper_Strings
{
    using System;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            Console.ReadLine()
                .ToUpper()
                .ToList()
                .ForEach(x => Console.Write(x));
        }
    }
}
