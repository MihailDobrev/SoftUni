namespace Tourist_Info
{
    using System;
    using System.Collections.Generic;
    public class TouristInformation
    {
        static void Main()
        {
            var metricUnits = new Dictionary<string, double>();

            string metricType = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());
            double multiplier = 0;
            string conversionMetricUnit=String.Empty;

            switch (metricType)
            {
                case "miles":
                    multiplier = 1.6;
                    conversionMetricUnit = "kilometers";
                    break;
                case "inches":
                    multiplier = 2.54;
                    conversionMetricUnit = "centimeters";
                    break;
                case "feet":
                    multiplier = 30;
                    conversionMetricUnit = "centimeters";
                    break;
                case "yards":
                    multiplier = 0.91;
                    conversionMetricUnit = "meters";
                    break;
                case "gallons":
                    multiplier = 3.8;
                    conversionMetricUnit = "liters";
                    break;
                default:
                    break;
            }
            double convertedValue = value * multiplier;
            Console.WriteLine($"{value} {metricType} = {convertedValue:F2} {conversionMetricUnit}");

        }
    }
}
