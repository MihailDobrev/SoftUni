namespace _02.VehiclesExtension
{
    using System;
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set { base.FuelConsumption = value + 0.9; }
        }

        public override void Refuel(double refuelingLitters)
        {

            if (refuelingLitters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (refuelingLitters + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {refuelingLitters} fuel in the tank");
            }
            else
            {
                FuelQuantity += refuelingLitters;
            }
           
        }
    }
}
