
namespace _4.Month_Printer
{
    using System;
    public class MonthPrinter
    {
        static void Main()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "Otober", "November", "December" };

            var month = int.Parse(Console.ReadLine());

            if (month>0 && month<13)
            {
                Console.WriteLine(months[month - 1]);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
