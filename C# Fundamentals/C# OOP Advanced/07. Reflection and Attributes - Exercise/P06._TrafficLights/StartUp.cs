namespace P06._TrafficLights
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] lightSignals = Console.ReadLine().Split();
            List<TrafficLight> trafficLights = new List<TrafficLight>();

            foreach (var lightSignal in lightSignals)
            {
                trafficLights.Add(new TrafficLight(lightSignal));
            }
            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                trafficLights.ForEach(l => l.ChangeLights());
                Console.WriteLine(string.Join(" ",trafficLights));
            }
        }
    }
}
