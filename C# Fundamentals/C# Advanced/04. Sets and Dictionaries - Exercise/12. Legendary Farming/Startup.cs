namespace _12.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input;

            Dictionary<string, int> keyMaterialRecords = new Dictionary<string, int>()
            {
                {"shards",0},
                {"fragments",0},
                {"motes",0},
            };
            Dictionary<string, int> junkMaterialRecords = new Dictionary<string, int>();
            Dictionary<string, string> keyMaterialsAndLegendaryItems = new Dictionary<string, string>()
            {
                {"shards","Shadowmourne"},
                {"fragments","Valanyr"},
                {"motes","Dragonwrath"},
            };

            string item = string.Empty;
            bool itemFound = false;


            while (!itemFound)
            {
                input = Console.ReadLine();

                string[] materialsData = input.Split();

                for (int counter = 0; counter < materialsData.Length; counter += 2)
                {

                    int quantity = int.Parse(materialsData[counter]);

                    string material = materialsData[counter + 1].ToLower();


                    if (keyMaterialsAndLegendaryItems.ContainsKey(material))
                    {

                        keyMaterialRecords[material] += quantity;
                        if (keyMaterialRecords[material] >= 250)
                        {
                            keyMaterialRecords[material] -= 250;
                            item = keyMaterialsAndLegendaryItems[material];
                            itemFound = true;
                            break;
                        }

                    }
                    else
                    {

                        if (!junkMaterialRecords.ContainsKey(material))
                        {
                            junkMaterialRecords[material] = quantity;
                        }
                        else
                        {
                            junkMaterialRecords[material] += quantity;
                        }

                    }
                }
            }

            Console.WriteLine($"{item} obtained!");

            foreach (var keyMaterialRecord in keyMaterialRecords.OrderByDescending(r => r.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyMaterialRecord.Key}: {keyMaterialRecord.Value}");
            }

            foreach (var junkMaterialRecord in junkMaterialRecords.OrderBy(r => r.Key))
            {
                Console.WriteLine($"{junkMaterialRecord.Key}: {junkMaterialRecord.Value}");
            }
        }
    }
}
