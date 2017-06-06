
namespace Price_Change_Alert
{
    using System;

    public class PriceChangeAlert
    {
        static void Main()
        {
            {
                int n = int.Parse(Console.ReadLine());
                double significanceThreshold = double.Parse(Console.ReadLine());
                double firstPrice = double.Parse(Console.ReadLine());

                for (int i = 0; i < n - 1; i++)
                {
                    double prices = double.Parse(Console.ReadLine());
                    double difference = CalculateDifference(firstPrice, prices);
                    bool isSignificantDifference = isThereDifference(difference, significanceThreshold);
                    string message = PrintMessage(prices, firstPrice, difference, isSignificantDifference);
                    Console.WriteLine(message);
                    firstPrice = prices;
                }
            }
        }
        private static string PrintMessage(double prices, double firstPrice, double difference, bool isSignificantDifference)
        {
            string message = "";
            if (difference == 0)
            {
                message = string.Format("NO CHANGE: {0}", prices);
            }
            else if (!isSignificantDifference)
            {
                message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", firstPrice, prices, difference * 100);
            }
            else if (isSignificantDifference && (difference > 0))
            {
                message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", firstPrice, prices, difference * 100);
            }
            else if (isSignificantDifference && (difference < 0))
                message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", firstPrice, prices, difference * 100);
            return message;
        }
        private static bool isThereDifference(double difference, double significanceThreshold)
        {
            if (Math.Abs(difference) >= significanceThreshold)
            {
                return true;
            }
            return false;
        }

        private static double CalculateDifference(double firstPrice, double prices)
        {
            double difference = (prices - firstPrice) / firstPrice;
            return difference;
        }
    }
}
