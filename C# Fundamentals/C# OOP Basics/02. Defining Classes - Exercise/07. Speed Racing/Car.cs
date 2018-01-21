namespace _07.Speed_Racing
{
    public class Car
    {
        private string model;

        private double fuelConsumption;

        private double fuelAmount;

        private double distanceTravelled;

        public Car(string model, double fuelConsumption, double fuelAmount)
        {
            this.model = model;
            this.fuelConsumption = fuelConsumption;
            this.fuelAmount = fuelAmount;
            this.distanceTravelled = 0;
        }

        public double DistanceTravelled
        {
            get { return distanceTravelled; }
            set { distanceTravelled = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double CalculateFuelLeft(double amountOfKM)
        {

            return this.fuelAmount - (this.fuelConsumption * amountOfKM);
        }

    }
}
