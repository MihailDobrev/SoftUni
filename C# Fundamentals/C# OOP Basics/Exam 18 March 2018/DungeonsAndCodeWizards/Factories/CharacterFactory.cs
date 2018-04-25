namespace DungeonsAndCodeWizards.Factories
{
    using System;
    using DungeonsAndCodeWizards.Characters;
    using DungeonsAndCodeWizards.Enums;

    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            object factionType;
            bool factionFound = Enum.TryParse(typeof(Faction), faction, out factionType);
            if (!factionFound)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(name, (Faction)factionType);
                case "Cleric":
                    return new Cleric(name, (Faction)factionType);
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");                   
            }

            //Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == characterType);
            //if (characterType == null)
            //{
            //    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            //}

            //return (Character)Activator.CreateInstance(type, name, (Faction)factionType);
        }
    }
}
