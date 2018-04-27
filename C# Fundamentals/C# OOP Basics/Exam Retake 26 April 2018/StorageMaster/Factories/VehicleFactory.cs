using StorageMaster.Vehicles;
using System;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        //This factory class with method has no real usage in the current project and it was only done as a bonus task for the exam
        public Vehicle CreateVehicle(string type)
        {

            switch (type)
            {
                case "Semi":
                    return new Semi();
                case "Truck":
                    return new Truck();
                case "Van":
                    return new Van();
                default:
                    throw new InvalidOperationException($"Invalid vehicle type!");
            }

        }
    }
}
