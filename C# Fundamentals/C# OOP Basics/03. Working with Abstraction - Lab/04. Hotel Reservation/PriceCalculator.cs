namespace _04._Hotel_Reservation
{
    public class PriceCalculator
    {
        public PriceCalculator(decimal pricePerDay, int numberOfDays, string season)
        {
            PricePerDay = pricePerDay;
            Days = numberOfDays;
            Season = season;
            DiscountType = "None";
        }

        public decimal PricePerDay { get; set; }

        public int Days { get; set; }

        public string Season { get; set; }

        public string DiscountType { get; set; }

        public decimal CalculatePrice()
        {
            int multiplier = 0;
            switch (Season)
            {
                case "Autumn":
                    multiplier = 1;
                    break;
                case "Spring":
                    multiplier = 2;
                    break;
                case "Winter":
                    multiplier = 3;
                    break;
                case "Summer":
                    multiplier = 4;
                    break;
                default:
                    break;
            }

            decimal priceWithoutDiscount = PricePerDay * Days * multiplier;

            int discount = 0;
            switch (DiscountType)
            {
                case "VIP":
                    discount = 20;
                    break;
                case "SecondVisit":
                    discount = 10;
                    break;
                case "None":
                    discount = 0;
                    break;
                default:
                    break;
            }

            decimal totalPrice = priceWithoutDiscount - (priceWithoutDiscount * discount / 100);
            return totalPrice;
        }
    }
}
