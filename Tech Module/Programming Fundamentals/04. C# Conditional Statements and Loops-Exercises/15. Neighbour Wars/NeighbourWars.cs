
namespace _15.Neighbour_Wars
{
    using System;
   
    public class NeighbourWars
    {
        static void Main()
        {
            int damageOfPesho = int.Parse(Console.ReadLine());
            int damageOfGosho = int.Parse(Console.ReadLine());
            int healthOfPesho = 100;
            int healthOfGosho = 100;
            int round = 0;

            while (healthOfPesho > 0 && healthOfGosho > 0)
            {
                round++;
                healthOfGosho -= damageOfPesho;
                if (healthOfGosho<=0)
                {
                    break;
                }
                Console.WriteLine($"Pesho used Roundhouse kick and reduced Gosho to {healthOfGosho} health.");

                if (round % 3 == 0)
                {
                    healthOfGosho += 10;
                    healthOfPesho += 10;
                }

                round++;
                healthOfPesho -= damageOfGosho;
                if (healthOfPesho <= 0)
                {
                    break;
                }
                Console.WriteLine($"Gosho used Thunderous fist and reduced Pesho to {healthOfPesho} health.");                
                if (round % 3 == 0)
                {
                    healthOfGosho += 10;
                    healthOfPesho += 10;
                }
            }
            if (healthOfGosho<healthOfPesho)
            {
                Console.WriteLine($"Pesho won in {round}th round.");
            }
            else
            {
                Console.WriteLine($"Gosho won in {round}th round.");
            }


        }
    }
}
