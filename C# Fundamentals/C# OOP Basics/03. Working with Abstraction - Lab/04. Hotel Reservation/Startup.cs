namespace _04._Hotel_Reservation
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            string[] reservationArgs = ReadInput();
            PrintTotalPrice(reservationArgs);           
        }

        private static void PrintTotalPrice(string[] reservationArgs)
        {
            decimal pricePerDay = decimal.Parse(reservationArgs[0]);
            int days = int.Parse(reservationArgs[1]);
            string season = reservationArgs[2];
            PriceCalculator priceCalc = new PriceCalculator(pricePerDay, days, season);

            if (reservationArgs.Length == 4)
            {
                string discountType = reservationArgs[3];
                priceCalc.DiscountType = discountType;
            }

            decimal totalPrice = priceCalc.CalculatePrice();
            Console.WriteLine($"{totalPrice:F2}");
        }

        private static string[] ReadInput()
        {
            string[] reservationArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return reservationArgs;
        }
    }
}
