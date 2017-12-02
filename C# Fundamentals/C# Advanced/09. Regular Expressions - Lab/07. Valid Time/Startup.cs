namespace _07.Valid_Time
{
    using System;
    using System.Text.RegularExpressions;
    public class Startup
    {
        public static void Main()
        {
            string timeInput = Console.ReadLine();

            string correctTimePattern = @"^[0-1][0-9]:([0-5][0-9]):[0-5][0-9] [AP]M$";

            Regex regex = new Regex(correctTimePattern);

            while (timeInput!="END")
            {
                if (regex.IsMatch(timeInput))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                timeInput = Console.ReadLine();
            }
        }
    }
}
