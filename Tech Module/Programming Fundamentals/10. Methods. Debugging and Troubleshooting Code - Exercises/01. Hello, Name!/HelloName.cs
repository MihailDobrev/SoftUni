namespace Hello__Name_
{
    using System;
    public class HelloName
    {
        static void Main()
        {
            string name = Console.ReadLine();
            PrintName(name);
        }

        private static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
