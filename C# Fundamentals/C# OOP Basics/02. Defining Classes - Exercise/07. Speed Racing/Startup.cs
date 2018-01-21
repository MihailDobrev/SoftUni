namespace _07.Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int line = 0; line < numberOfCars; line++)
            {
                string[] carInfo = Console.ReadLine().Split();

                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);
                Car car = new Car(model, fuelConsumption, fuelAmount);
                cars.Add(car);
            }

            string input;
            while ((input=Console.ReadLine())!="End")
            {
                string[] commandArgs = input.Split();

                string model = commandArgs[1];
                double amountOfKM = double.Parse(commandArgs[2]);
                Car drivedCar = cars.Where(x => x.Model == model).First();
                if (drivedCar.FuelAmount>=drivedCar.FuelConsumption*amountOfKM)
                {
                    double fuelLeft = drivedCar.CalculateFuelLeft(amountOfKM);
                    drivedCar.FuelAmount = fuelLeft;
                    drivedCar.DistanceTravelled += amountOfKM;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                
            }

            cars.ForEach(c => Console.WriteLine($"{c.Model} {c.FuelAmount:f2} {c.DistanceTravelled}"));
        }
    }
}
