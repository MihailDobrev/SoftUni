namespace _01.Students_Results
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int students = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));

            for (int counter = 0; counter < students; counter++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                string student = input[0].TrimEnd(new char[] { ' ' });

                double[] results = input[1]
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                double average = results.Average();

                Console.WriteLine(string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|", student, results[0], results[1], results[2], average));
            }
        }
    }
}
