namespace P06._TrafficLights
{
    using System;

    public class TrafficLight
    {
        public Light Light { get; private set; }

        public TrafficLight(string light)
        {
            this.Light = (Light)Enum.Parse(typeof(Light), light);
        }

        public void ChangeLights()
        {
            this.Light += 1;
            this.Light = (int)this.Light > 2 ? 0 : this.Light;
        }

        public override string ToString()
        {
            return $"{this.Light}";
        }

    }
}
