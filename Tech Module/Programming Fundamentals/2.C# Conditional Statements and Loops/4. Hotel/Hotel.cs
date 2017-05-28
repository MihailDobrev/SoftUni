
namespace _4.Hotel
{
    using System;

    class Hotel
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double doublePrice = 0;
            double suitePrice = 0;

            double studioDiscount = 0;
            double doubleDiscount = 0;
            double suiteDiscount = 0;
            var prices = new double[3];

            if (month == "May" || month == "October")
            {
                studioPrice = 50; doublePrice = 65; suitePrice = 75;
                studioDiscount = nightsCount > 7 ? 5 : 0;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 60; doublePrice = 72; suitePrice = 82;
                doubleDiscount = nightsCount > 14 ? 10 : 0;
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                studioPrice = 68; doublePrice = 77; suitePrice = 89;
                suiteDiscount = nightsCount > 14 ? 15 : 0;
            }
            prices[0] = studioPrice - (studioPrice * studioDiscount / 100.00);
            prices[1] = doublePrice - (doublePrice * doubleDiscount / 100.00);
            prices[2] = suitePrice - (suitePrice * suiteDiscount / 100.00);

            var typesOfRooms = new string[] { "Studio", "Double", "Suite" };
            for (int i = 0; i <= 2; i++)
            {
                double totalPrice = 0;
                if (nightsCount > 7 && (month == "October" || month == "September") && i == 0)
                {
                    nightsCount--;
                    totalPrice = nightsCount * prices[i];
                    nightsCount++;
                }
                else
                {
                    totalPrice = nightsCount * prices[i];
                }
                Console.WriteLine($"{typesOfRooms[i]}: {totalPrice:F2} lv.");
            }

        }
    }
}
