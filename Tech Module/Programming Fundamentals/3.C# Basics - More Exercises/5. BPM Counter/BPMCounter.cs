

namespace _5.BPM_Counter
{
    using System;

    public class BPMCounter
    {
        static void Main()
        {
            double beatsPerMinute = double.Parse(Console.ReadLine());
            double numberOfBeats = double.Parse(Console.ReadLine());

            double bars = Math.Round(numberOfBeats / 4.0, 1);

            int timeInSeconds = (int)(numberOfBeats / beatsPerMinute * 60);

            int minutes = 0;
            if (timeInSeconds >= 60)
            {
                minutes = timeInSeconds / 60;
                timeInSeconds -= minutes * 60;
            }
            Console.WriteLine($"{bars} bars - {minutes}m {timeInSeconds}s");
        }
    }
}
