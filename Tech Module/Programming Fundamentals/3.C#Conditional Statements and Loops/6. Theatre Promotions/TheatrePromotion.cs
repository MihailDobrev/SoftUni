
namespace _6.Theatre_Promotions
{
    using System;
    public class TheatrePromotion
    {
        static void Main()
        {
            var day = Console.ReadLine().ToLower();
            var age = int.Parse(Console.ReadLine());
            int price = 0;

            if (age >= 0 && age<=122)
            {
                switch (day)
                {
                    case "weekday":
                        price = ReturnPrice(age, 12, 18, 12);
                        break;
                    case "weekend":
                        price = ReturnPrice(age, 15, 20, 15);
                        break;
                    case "holiday":
                        price = ReturnPrice(age, 5, 12, 10);
                        break;
                    default:
                        break;
                }

                if (price>0)
                {
                    Console.WriteLine(price + "$");
                }
                else
                {
                    Console.WriteLine("Error");
                }   
            }
            else
            {
                Console.WriteLine("Error!");
            }    

        }

        private static int ReturnPrice(int age, int priceOne, int priceTwo, int priceThree)
        {
            int price = 0;
            if (age >= 0 && age <= 18)
            {
                price = priceOne;
            }
            else if (age > 18 && age <= 64)
            {
                price = priceTwo;
            }
            else if (age > 64 && age <= 122)
            {
                price = priceThree;
            }
            return price;
        }
    }
}
