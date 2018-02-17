namespace _05.Pizza_Calories
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Queue<string> commands = new Queue<string>();

            while (input != "END")
            {
                commands.Enqueue(input);
                input = Console.ReadLine();
            }

            int totalCommands = commands.Count;

            try
            {
                switch (totalCommands)
                {
                    case 1:
                        commands = PrintDoughCalories(commands);
                        break;
                    case 2:
                        commands = PrintDoughCalories(commands);
                        PrintToppingsCalories(commands);
                        break;
                    default:
                        PrintPizzaCalories(commands);
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }     
            
        }

        private static void PrintPizzaCalories(Queue<string> commands)
        {
            Pizza pizza = new Pizza();

            while (commands.Count > 0)
            {
                string command = commands.Dequeue();
                string[] inputArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (inputArgs[0])
                {
                    case "Pizza":
                        string pizzaName = inputArgs[1];
                        int toppings = int.Parse(inputArgs[2]);
                        pizza.Name = pizzaName;
                        pizza.NumberOFToppings = toppings;
                        break;
                    case "Dough":
                        string flourType = inputArgs[1];
                        string bakingTechnique = inputArgs[2];
                        double doughWeight = double.Parse(inputArgs[3]);
                        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
                        pizza.Dough = dough;
                        break;
                    case "Topping":
                        string toppingsType = inputArgs[1];
                        double toppingsWeight = double.Parse(inputArgs[2]);
                        Topping topping = new Topping(toppingsType, toppingsWeight);
                        pizza.AddTopping(topping);
                        break;
                    default:
                        break;
                }
            }

            double totalCalories = pizza.CalculateCalories();
            Console.WriteLine($"{pizza.Name} - {totalCalories:f2} Calories.");
        }

        private static void PrintToppingsCalories(Queue<string> commands)
        {
            while (commands.Count > 0)
            {
                string command = commands.Dequeue();
                string[] toppingArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string toppingsType = toppingArgs[1];
                double toppingsWeight = double.Parse(toppingArgs[2]);
                Topping topping = new Topping(toppingsType, toppingsWeight);
                Console.WriteLine($"{topping.CalculateCalories():f2}");
            }
        }

        private static Queue<string> PrintDoughCalories(Queue<string> commands)
        {
            string command = commands.Dequeue();
            string[] inputArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string flourType = inputArgs[1];
            string bakingTechnique = inputArgs[2];
            double doughWeight = double.Parse(inputArgs[3]);
            Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
            Console.WriteLine($"{dough.CalculateCalories():f2}");
            return commands;
        }
    }
}
