namespace _9.Legendary_Farming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LegendaryFarming
    {
        static void Main()
        {

            Dictionary<string, int> collectedMaterials = new Dictionary<string, int>();
            collectedMaterials.Add("shards", 0);
            collectedMaterials.Add("fragments", 0);
            collectedMaterials.Add("motes", 0);

            int counter = 0;
            int quantity = 0;
            string material = "";
            string maxMaterial = "";

            while (counter < 250)
            {

                string[] materials = Console.ReadLine().ToLower().Split(' ');

                for (int index = 0; index < materials.Length; index += 2)
                {
                    quantity = int.Parse(materials[index]);

                    material = materials[index + 1];

                    if (!collectedMaterials.ContainsKey(material))
                    {
                        collectedMaterials[material] = quantity;
                    }
                    else
                    {
                        collectedMaterials[material] += quantity;
                    }

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        counter = collectedMaterials[material];

                        if (counter >= 250)
                        {
                            maxMaterial = material;
                            collectedMaterials[material] = counter - 250;
                            break;
                        }
                    }
                }
            }

            var legendaryItems = new Dictionary<string, string>();
            legendaryItems.Add("shards", "Shadowmourne");
            legendaryItems.Add("fragments", "Valanyr");
            legendaryItems.Add("motes", "Dragonwrath");

            Console.WriteLine($"{legendaryItems[maxMaterial]} obtained!");


            var orderedKeyMaterials = collectedMaterials
                .Where(m => m.Key == "shards" || m.Key == "fragments" || m.Key == "motes")
                .OrderByDescending(x => x.Value)
                .ThenBy(y => y.Key)
                .ToDictionary(z => z.Key, z => z.Value);

            var remainingMaterials = collectedMaterials
                .Where(m => m.Key != "shards" && m.Key != "fragments" && m.Key != "motes")
                .OrderBy(p => p.Key)
                .ToDictionary(g => g.Key, g => g.Value);

            foreach (var firstMaterialPair in orderedKeyMaterials)
            {
                Console.WriteLine($"{firstMaterialPair.Key}: {firstMaterialPair.Value}");
            }
            foreach (var secondMaterialPair in remainingMaterials)
            {
                Console.WriteLine($"{secondMaterialPair.Key}: {secondMaterialPair.Value}");
            }
        }
    }
}
