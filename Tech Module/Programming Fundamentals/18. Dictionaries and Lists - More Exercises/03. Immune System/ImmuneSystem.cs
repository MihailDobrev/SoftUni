

namespace _03.Immune_System
{
    using System;
    using System.Collections.Generic;
    public class ImmuneSystem
    {
        static void Main()
        {
            int health = int.Parse(Console.ReadLine());
            int initialHealth = health;
            var virusName = Console.ReadLine();
   
            List<string> viruses = new List<string>();
           
            while (virusName!="end")
            {
                int sum = 0;
                int virusStrenght = 0;

                foreach (var character in virusName)
                {
                    sum += character;   
                }
                virusStrenght = sum / 3;

                int secondsToDefeat = 0;
               

                if (viruses.Contains(virusName))
                {
                    secondsToDefeat = (virusStrenght * virusName.Length) / 3;
                }
                else
                {
                    secondsToDefeat = (virusStrenght * virusName.Length);

                }

                viruses.Add(virusName);
                int minutes = 0;
                int seconds = 0;

                minutes = secondsToDefeat / 60;
                seconds = secondsToDefeat - (minutes * 60);

                Console.WriteLine($"Virus {virusName}: { virusStrenght} => { secondsToDefeat} seconds");
                health -= secondsToDefeat;

                if (health>0)
                {
                    Console.WriteLine($"{virusName} defeated in {minutes}m {seconds}s.");
                    Console.WriteLine($"Remaining health: {health}");

                    if (health+health*0.2>initialHealth)
                    {
                        health = initialHealth;
                    }
                    else
                    {
                        health += (int)(health * 0.2);
                    } 
                }
                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    break;
                }

                virusName = Console.ReadLine();
            }

            if (health>0)
            {
                Console.WriteLine($"Final Health: {health}");
            }
            
        }
    }
}
