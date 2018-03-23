namespace _02.VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;           
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > tankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public abstract void Refuel(double refuelingLitters);

        public virtual string Drive(double kilometers)
        {
            string message = string.Empty;
            FuelQuantity -= kilometers * FuelConsumption;

            if (FuelQuantity < 0)
            {
                message = $"{this.GetType().Name} needs refueling";
                FuelQuantity += kilometers * FuelConsumption;
            }
            else
            {
                message = $"{this.GetType().Name} travelled {kilometers} km";
            }

            return message;
        }
    }
}
