namespace _03.WildFarm
{
    using _03.WildFarm.Animals.Birds;
    using _03.WildFarm.Animals.Mammals;
    using _03.WildFarm.Animals.Mammals.Felines;
    using _03.WildFarm.Foods;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static Queue<Animal> animals = new Queue<Animal>();
        public static Queue<Food> foods = new Queue<Food>();
        public static void Main()
        {
            ReadAnimalsAndFoods();
            PrintAnimalInfo();
        }

        private static void PrintAnimalInfo()
        {
            StringBuilder sb = new StringBuilder();

            while (foods.Count>0)
            {
                Animal animal = animals.Dequeue();
                Food food = foods.Dequeue();
                sb.AppendLine(animal.ProduceSound());
                try
                {
                    animal.EatFood(food.Name, food.Quantity);
                }
                catch (ArgumentException ae)
                {
                    sb.AppendLine(ae.Message);                  
                }
                animals.Enqueue(animal);
            }

            while (animals.Count>0)
            {
                Animal animal = animals.Dequeue();
                sb.AppendLine(animal.ToString());
            }

            Console.Write(sb.ToString());
        }

        private static void ReadAnimalsAndFoods()
        {
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (animalInfo[0])
                {
                    case "Hen":
                        animals.Enqueue(new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3])));
                        break;
                    case "Owl":
                        animals.Enqueue(new Owl(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3])));
                        break;
                    case "Mouse":
                        animals.Enqueue(new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]));
                        break;
                    case "Cat":
                        animals.Enqueue(new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]));
                        break;
                    case "Dog":
                        animals.Enqueue(new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]));
                        break;
                    case "Tiger":
                        animals.Enqueue(new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]));
                        break;
                    default:
                        break;
                }

                switch (foodInfo[0])
                {
                    case "Vegetable":
                        foods.Enqueue(new Vegetable(double.Parse(foodInfo[1])));
                        break;
                    case "Fruit":
                        foods.Enqueue(new Fruit(double.Parse(foodInfo[1])));
                        break;
                    case "Meat":
                        foods.Enqueue(new Meat(double.Parse(foodInfo[1])));
                        break;
                    case "Seeds":
                        foods.Enqueue(new Seeds(double.Parse(foodInfo[1])));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
