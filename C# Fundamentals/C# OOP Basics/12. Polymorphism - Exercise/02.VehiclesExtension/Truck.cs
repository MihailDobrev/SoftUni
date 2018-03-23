namespace _02.VehiclesExtension
{
    using System;
	
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConumption, double tankCapacity)
            : base(fuelQuantity, fuelConumption, tankCapacity)
        {
        }
        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set { base.FuelConsumption = value + 1.6; }
        }

        public override void Refuel(double refuelingLitters)
        {
            if (refuelingLitters<=0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (refuelingLitters+FuelQuantity>TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {refuelingLitters} fuel in the tank");
            }
            else
            {
                FuelQuantity += (refuelingLitters * 0.95);
            }

        }
    }
}
