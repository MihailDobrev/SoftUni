namespace _02.Email_Me
{
    using System;
    using System.Linq;

    public class EmailMe
    {
        static void Main()
        {
            var inputLine = Console.ReadLine().Split('@').ToList();
            var firstPart = inputLine[0].ToList();
            var secondPart = inputLine[1].ToList();

            var firstSum = firstPart.Select(a => (int)a).Sum();
            var secondSum = secondPart.Select(b => (int)b).Sum();

            Console.WriteLine(secondSum <= firstSum ? "Call her!" : "She is not the one.");
        }
    }
}
