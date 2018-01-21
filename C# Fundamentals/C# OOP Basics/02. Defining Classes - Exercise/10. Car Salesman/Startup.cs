namespace _10.Car_Salesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int totalEngines = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            for (int line = 0; line < totalEngines; line++)
            {
                string[] engineArgs = Console.ReadLine().Split();
                string model = engineArgs[0];
                int power = int.Parse(engineArgs[1]);

                int powerDisplacement = -9999999;
                string efficiency = "n/a";

                int parsed = 0;
                bool isNumber = false;
                Engine engine = new Engine(model, power);

                switch (engineArgs.Length)
                {
                    case 3:
                        isNumber = int.TryParse(engineArgs[2], out parsed);
                        if (isNumber)
                        {
                            powerDisplacement = parsed;
                        }
                        else
                        {
                            efficiency = engineArgs[2];
                        }
                     
                        break;
                    case 4:
                        isNumber = int.TryParse(engineArgs[2], out parsed);
                        if (isNumber)
                        {
                            powerDisplacement = parsed;
                            efficiency = engineArgs[3];

                        }
                        else
                        {
                            efficiency = engineArgs[2];
                            powerDisplacement = int.Parse(engineArgs[3]);

                        }
                        
                        break;
                    default:
                        break;
                }
                engine.PowerDisplacement = powerDisplacement;
                engine.Efficiency = efficiency;
                engines.Add(engine);

            }
            int totalCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int line = 0; line < totalCars; line++)
            {
                string[] carInput = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

                string model = carInput[0];
                string engine = carInput[1];
                string color = "n/a";
                int weight = -9999999;
                Engine engineObject = engines.Where(e => e.Model == engine).First();
                Car car = new Car(model, engineObject);
                

                int parsed = 0;
                bool isNumber = false;

                switch (carInput.Length)
                {
                    case 3:
                        isNumber = int.TryParse(carInput[2], out parsed);
                        if (isNumber)
                        {
                            weight = parsed;
                        }
                        else
                        {
                            color = carInput[2];
                        }
                        break;
                    case 4:
                        isNumber = int.TryParse(carInput[2], out parsed);
                        if (isNumber)
                        {
                            weight = parsed;
                            color = carInput[3];

                        }
                        else
                        {
                            color = carInput[2];
                            weight = int.Parse(carInput[3]);

                        }
                      
                        break;
                    default:
                        break;
                }
                car.Weight = weight;
                car.Color = color;
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

        }
    }
}
