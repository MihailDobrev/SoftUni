
namespace _3.Restaurant_Disc
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class RestaurantDiscount
    {
        static void Main(string[] args)
        {
            int groupSize = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();
            string hallSize=string.Empty;
            double hallSizePrice = 0;

            if (groupSize<=50)
            {
                hallSize = "Small Hall";
                hallSizePrice = 2500;

            }
            else if (groupSize>50 && groupSize<=100)
            {
                hallSize = "Terrace";
                hallSizePrice = 5000;
            }
            else if(groupSize>100 && groupSize<=120)
            {
                hallSize = "Great Hall";
                hallSizePrice = 7500;
            }
            

            double discount = 0;
            double packagePrice = 0;

            switch (package)
            {
                case "Normal": discount = 5; packagePrice=500 ; break;
                case "Gold": discount = 10; packagePrice = 750; break;
                case "Platinum": discount = 15; packagePrice = 1000; break;
               
            }
            var totalPrice = hallSizePrice + packagePrice;
            totalPrice = (totalPrice - (totalPrice* discount / 100.00))/groupSize;

            if (groupSize<=120)
            {
                Console.WriteLine($"We can offer you the {hallSize}");
                Console.WriteLine($"The price per person is {totalPrice:F2}$");
            }            
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
        }
    }
}
