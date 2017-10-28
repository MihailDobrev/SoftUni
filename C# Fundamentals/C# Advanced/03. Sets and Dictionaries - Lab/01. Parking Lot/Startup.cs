namespace _01.Parking_Lot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
	
    public class Startup
    {
        public static void Main()
        {
            string input = string.Empty;
            SortedSet<string> carsInside = new SortedSet<string>();
            input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputData = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string direction = inputData[0];
                string licencePlate = inputData[1];

                if (direction == "IN")
                {
                    carsInside.Add(licencePlate);
                }
                else if (direction == "OUT")
                {
                    carsInside.Remove(licencePlate);
                }

                input = Console.ReadLine();
            }

            if (carsInside.Count > 0)
            {
                foreach (var car in carsInside)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
