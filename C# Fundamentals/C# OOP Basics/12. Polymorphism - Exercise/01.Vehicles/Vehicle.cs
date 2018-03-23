namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
		
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }
        
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
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

            if (FuelQuantity<0)
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
