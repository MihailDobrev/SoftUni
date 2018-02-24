namespace Animals
{
    using global::Animals.Animals;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
           Queue<Animal> animals = GetAnimals();
           PrintAnimals(animals);
        }

        private static void PrintAnimals(Queue<Animal> animals)
        {
            while (animals.Count>0)
            {
                Console.WriteLine(animals.Dequeue());
            }
        }

        private static Queue<Animal> GetAnimals()
        {
            string input;
            Queue<Animal> animals = new Queue<Animal>();

            while ((input = Console.ReadLine()) != "Beast!")
            {
                string animalType = input;
                string[] animalInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = animalInfo[2];

                    switch (animalType)
                    {
                        case "Dog":
                            animals.Enqueue(new Dog(gender, age, name));
                            break;
                        case "Frog":
                            animals.Enqueue(new Frog(gender, age, name));
                            break;
                        case "Cat":
                            animals.Enqueue(new Cat(gender, age, name));
                            break;
                        case "Kitten":
                            animals.Enqueue(new Kitten(gender, age, name));
                            break;
                        case "Tomcat":
                            animals.Enqueue(new Tomcat(gender, age, name));
                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return animals;
        }
    }
}
