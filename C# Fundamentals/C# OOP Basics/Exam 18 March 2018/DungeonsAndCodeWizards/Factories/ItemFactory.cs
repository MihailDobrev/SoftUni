namespace DungeonsAndCodeWizards.Factories
{
    using DungeonsAndCodeWizards.Items;
    using System;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {

            switch (itemName)
            {
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            //Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == itemName);

            //if (type==null)
            //{
            //    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            //}
            //return (Item)Activator.CreateInstance(type);
        }
    }
}
