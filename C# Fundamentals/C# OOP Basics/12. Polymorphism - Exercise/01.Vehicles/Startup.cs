namespace _01.Vehicles
{
    using System;
	
    public class Startup
    {
        public static void Main()
        {
           
            string[] carInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int totalCommands = int.Parse(Console.ReadLine());

            for (int command = 0; command < totalCommands; command++)
            {
                string[] commandInfo = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
                string vehicleType= commandInfo[1];
                double litters = double.Parse(commandInfo[2]);

                switch (commandInfo[0])
                {
                    case "Drive":
                        if (vehicleType == "Car")
                        {
                            Console.WriteLine(car.Drive(litters));
                        }
                        else if (vehicleType == "Truck")
                        {
                            Console.WriteLine(truck.Drive(litters));
                        }
                        break;
                    case "Refuel":
                        if (vehicleType == "Car")
                        {
                            car.Refuel(litters);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(litters);
                        }
                        break;                    
                    default:
                        break;
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
