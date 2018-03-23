namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }
        
        public override double FuelConsumption
        {
            get => base.FuelConsumption;
            set { base.FuelConsumption = value + 0.9; }
        }

        public override void Refuel(double refuelingLitters)
        {
            FuelQuantity += refuelingLitters;
        }
    }
}
