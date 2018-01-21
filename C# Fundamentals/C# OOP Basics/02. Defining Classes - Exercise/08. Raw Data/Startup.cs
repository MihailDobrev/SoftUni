namespace _08.Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            int amountOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int line = 0; line < amountOfCars; line++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                string model = inputArgs[0];
                int engineSpeed = int.Parse(inputArgs[1]);
                int enginePower = int.Parse(inputArgs[2]);
                int cargoWeight = int.Parse(inputArgs[3]);
                string cargoType = inputArgs[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                List<Tire> tiresOfACar = new List<Tire>();

                int counter = 4;
                for (int i = 1; i <= 4; i++)
                {
                    double tirePressure = double.Parse(inputArgs[i + counter]);
                    int tireAge = int.Parse(inputArgs[i + counter + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);
                    tiresOfACar.Add(tire);
                    counter++;
                }
                Car car = new Car(model, engine, cargo, tiresOfACar);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            IEnumerable<Car> searchedCars;

            switch (command)
            {
                case "fragile":

                    searchedCars = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1));
                    foreach (var car in searchedCars)
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                case "flamable":
                    searchedCars = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250);
                    foreach (var car in searchedCars)
                    {
                        Console.WriteLine(car.Model);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
