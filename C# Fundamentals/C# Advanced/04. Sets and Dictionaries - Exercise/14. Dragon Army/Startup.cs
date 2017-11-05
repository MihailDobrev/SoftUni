namespace _14.Dragon_Army
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            byte numberOfDragons = byte.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, Dragon>> dragonLog = new Dictionary<string, Dictionary<string, Dragon>>();
            string[] defaultValues = new string[] { "45", "250", "10" };

            for (byte i = 0; i < numberOfDragons; i++)
            {
                string[] dragonInput = Console.ReadLine().Split();

                for (int index = 2; index < dragonInput.Length; index++)
                {
                    if (dragonInput[index] == "null")
                    {
                        dragonInput[index] = defaultValues[index - 2];
                    }
                }

                string dragonType = dragonInput[0];
                string dragonName = dragonInput[1];
                int damage = int.Parse(dragonInput[2]);
                int health = int.Parse(dragonInput[3]);
                int armor = int.Parse(dragonInput[4]);

                Dragon dragon = new Dragon()
                {
                    Name = dragonName,
                    Damage = damage,
                    Health = health,
                    Armor = armor
                };

                if (!dragonLog.ContainsKey(dragonType))
                {

                    dragonLog[dragonType] = new Dictionary<string, Dragon>();

                }

                if (!dragonLog[dragonType].ContainsKey(dragonName))
                {
                    dragonLog[dragonType][dragonName] = dragon;
                }
                else
                {
                    dragonLog[dragonType][dragonName].Damage = damage;
                    dragonLog[dragonType][dragonName].Health = health;
                    dragonLog[dragonType][dragonName].Armor = armor;
                }
            }


            foreach (var pair in dragonLog)
            {
                double averageDamage = pair.Value.Values.Average(d => d.Damage);
                double averageHealth = pair.Value.Values.Average(h => h.Health);
                double averageArmor = pair.Value.Values.Average(a => a.Armor);

                Console.WriteLine($"{pair.Key}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                var dragons = pair.Value;
                foreach (var dragonPair in dragons.OrderBy(name=>name.Key))
                {
                    Console.WriteLine($"-{dragonPair.Key} -> damage: {dragonPair.Value.Damage}, health: {dragonPair.Value.Health}, armor: {dragonPair.Value.Armor}");
                }
            }
        }
    }
}
