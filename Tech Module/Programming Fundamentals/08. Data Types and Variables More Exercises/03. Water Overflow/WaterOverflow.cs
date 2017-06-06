
namespace Water_Overflow
{
    using System;

    public class WaterOverflow
    {
        static void Main()
        {
            byte numberOfWaterFills = byte.Parse(Console.ReadLine());

            short capacity=byte.MaxValue;
            short litersInside = 0;

            for (byte i = 0; i < numberOfWaterFills; i++)
            {
                short waterLeters = short.Parse(Console.ReadLine());
                if (waterLeters + litersInside <= capacity)
                {
                    litersInside += waterLeters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(litersInside);
        }
    }
}
