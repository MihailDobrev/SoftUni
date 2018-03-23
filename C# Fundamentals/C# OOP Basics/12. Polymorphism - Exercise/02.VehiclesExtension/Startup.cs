namespace _02.VehiclesExtension
{
    using System;
	
    public class Startup
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            string[] busInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            int totalCommands = int.Parse(Console.ReadLine());
        
            for (int command = 0; command < totalCommands; command++)
            {
                string[] commandInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string vehicleType = commandInfo[1];
                double litters = double.Parse(commandInfo[2]);

                try
                {
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
                            else if (vehicleType == "Bus")
                            {
                                bus.FuelConsumption += 1.4;
                                Console.WriteLine(bus.Drive(litters));
                                bus.FuelConsumption -= 1.4;
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
                            else if (vehicleType == "Bus")
                            {
                                bus.Refuel(litters);
                            }
                            break;
                        case "DriveEmpty":
                            Console.WriteLine(bus.Drive(litters));
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
