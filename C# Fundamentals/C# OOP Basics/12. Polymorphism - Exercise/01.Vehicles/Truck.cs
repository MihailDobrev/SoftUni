namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConumption)
            : base(fuelQuantity, fuelConumption)
        {
        }
        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set { base.FuelConsumption = value + 1.6; }
        }

        public override void Refuel(double refuelingLitters)
        {
            base.FuelQuantity += (refuelingLitters * 0.95);
        }
    }
}
