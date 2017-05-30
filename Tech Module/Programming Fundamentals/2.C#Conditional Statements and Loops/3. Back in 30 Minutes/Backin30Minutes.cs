
namespace _3.Back_in_30_Minutes
{
    using System;
    public class Backin30Minutes
    {
        static void Main()
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (minutes + 30 >= 60)
            {

                if (hours < 23)
                {
                    minutes = minutes - 30;
                    hours++;
                }
                else
                {
                    minutes = minutes - 30;
                    hours++;
                    hours = hours - 24;    
                }

            }
            else
            {
                minutes += 30;
            }

            Console.WriteLine($"{hours}:{minutes.ToString("D2")}");
        }
    }
}
