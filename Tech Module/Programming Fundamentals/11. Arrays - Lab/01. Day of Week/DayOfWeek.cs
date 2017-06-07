namespace Day_of_Week
{
    using System;
    public class DayOfWeek
    {
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());

            string[] days = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (dayNumber>0 && dayNumber<8)
            {
                Console.WriteLine($"{days[dayNumber - 1]}");
            }
            else
            {
                Console.WriteLine("Invalid Day!");
            }
            
        }
    }
}
