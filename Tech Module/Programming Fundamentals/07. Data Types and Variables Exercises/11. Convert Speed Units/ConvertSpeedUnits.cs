
namespace _11.Convert_Speed_Units
{
    using System;
    public class ConvertSpeedUnits
    {
        static void Main()
        {
            float distance = float.Parse(Console.ReadLine());
            float hours = float.Parse(Console.ReadLine());
            float minutes = float.Parse(Console.ReadLine());
            float seconds = float.Parse(Console.ReadLine());
            float totalTimeSeconds = hours * 60 * 60 + minutes * 60 + seconds;

            float totalTimeHours = hours + minutes / 60f + seconds / 60f / 60f;
            float distanceInKM = distance / 1000f;
            float distanceInMiles = distance / 1609f;

            float speedMetersPerSecond = distance / totalTimeSeconds;
            float speedKmPerHour = distanceInKM / totalTimeHours;
            float speedMilesPerHour = distanceInMiles / totalTimeHours;

            Console.WriteLine(speedMetersPerSecond);
            Console.WriteLine(speedKmPerHour);
            Console.WriteLine(speedMilesPerHour);



        }
    }
}
