
namespace SentenceThief
{
    using System;

    public class SentenceTheThief
    {
        static void Main()
        {
            string numericalType = Console.ReadLine();
            long typeMaxValue = 0;

            switch (numericalType)
            {
                case "sbyte":
                    typeMaxValue = sbyte.MaxValue; break;
                case "int":
                    typeMaxValue = int.MaxValue; break;
                case "long":
                    typeMaxValue = long.MaxValue; break;
                default: break;
            }

            byte n = byte.Parse(Console.ReadLine());
            long closestIdToTheMax = long.MinValue;

            for (byte i = 0; i < n; i++)
            {
                long id = long.Parse(Console.ReadLine());
                if (closestIdToTheMax < id && id <= typeMaxValue)
                {
                    closestIdToTheMax = id;
                }
            }
           
            double sentence = closestIdToTheMax < 0 ? Math.Ceiling(closestIdToTheMax / (double)sbyte.MinValue) :
                sentence = Math.Ceiling(closestIdToTheMax / (double)sbyte.MaxValue);
            
            if (sentence==1)
            {
                Console.WriteLine($"Prisoner with id {closestIdToTheMax} is sentenced to {sentence} year");
            }
            else
            {
                Console.WriteLine($"Prisoner with id {closestIdToTheMax} is sentenced to {sentence} years");
            }
        }
    }
}
