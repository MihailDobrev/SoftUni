namespace _05.GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Dictionary<string, long>> bag = FillTheBag();
            PrintBagContent(bag);
        }

        private static void PrintBagContent(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static Dictionary<string, Dictionary<string, long>> FillTheBag()
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < safe.Length; i += 2)
            {
                string name = safe[i];
                long value = long.Parse(safe[i + 1]);

                string typeOfLoot = string.Empty;

                if (name.Length == 3)
                {
                    typeOfLoot = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    typeOfLoot = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    typeOfLoot = "Gold";
                }

                if (typeOfLoot == "")
                {
                    continue;
                }
                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + value)
                {
                    continue;
                }

                switch (typeOfLoot)
                {
                    case "Gem":
                        if (!bag.ContainsKey(typeOfLoot))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (value > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[typeOfLoot].Values.Sum() + value > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(typeOfLoot))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (value > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[typeOfLoot].Values.Sum() + value > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(typeOfLoot))
                {
                    bag[typeOfLoot] = new Dictionary<string, long>();
                }

                if (!bag[typeOfLoot].ContainsKey(name))
                {
                    bag[typeOfLoot][name] = 0;
                }

                bag[typeOfLoot][name] += value;
                if (typeOfLoot == "Gold")
                {
                    gold += value;
                }
                else if (typeOfLoot == "Gem")
                {
                    gems += value;
                }
                else if (typeOfLoot == "Cash")
                {
                    cash += value;
                }
            }

            return bag;
        }
    }
}
