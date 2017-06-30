
namespace _02.Vehicle_Catalogue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class VehicleCatalogue
    {
        static void Main()
        {
            string input;
            List<Vehicle> vehicles = new List<Vehicle>();

            while ((input=Console.ReadLine())!="End")
            {
                var vehicleInfo = input.Split();
                string carOrTruck=string.Empty;
                if (vehicleInfo[0].ToLower()=="car")
                {
                    carOrTruck = "Car";
                }
                else if(vehicleInfo[0].ToLower() == "truck")
                {
                    carOrTruck = "Truck";
                }

                Vehicle vehicle = new Vehicle()
                {
                    Type= carOrTruck,
                    Model=vehicleInfo[1],
                    Colour=vehicleInfo[2],
                    Horsepower=int.Parse(vehicleInfo[3])
                };
                vehicles.Add(vehicle);

            }
            string secondInput;
            List<string> vehicleOrder = new List<string>();
            while ((secondInput = Console.ReadLine())!= "Close the Catalogue")
            {
                vehicleOrder.Add(secondInput);
            }

            foreach (var vehicle in vehicleOrder)
            {
                foreach (var vehicleType in vehicles)
                {
                    if (vehicle == vehicleType.Model)
                    {
                        Console.WriteLine($"Type: {vehicleType.Type}");
                        Console.WriteLine($"Model: {vehicleType.Model}");
                        Console.WriteLine($"Color: {vehicleType.Colour}");
                        Console.WriteLine($"Horsepower: {vehicleType.Horsepower}");
                    }
                }                            
            }
            try
            {
                var averageCarHorsepower = vehicles.Where(x => x.Type.ToLower() == "car").Average(y => y.Horsepower);
                Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:F2}.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }

            
            try
            {
                var averageTruckHorsepower = vehicles.Where(x => x.Type.ToLower() == "truck").Average(y => y.Horsepower);
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:F2}.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
            
            
        }
    }
}
