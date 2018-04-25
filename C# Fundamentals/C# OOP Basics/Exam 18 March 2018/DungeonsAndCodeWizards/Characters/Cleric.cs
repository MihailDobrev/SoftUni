namespace DungeonsAndCodeWizards.Characters
{
    using DungeonsAndCodeWizards.Bags;
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Enums;
    using System;

    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction) 
            : base(name, 50, 25, 40, new Backpack(), faction)
        {
            this.BaseHealth = 50;
            this.BaseArmor = 25;
            this.RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
              
                if (this.Faction != character.Faction)
                {
                    throw new InvalidOperationException($"Cannot heal enemy character!");
                }
                character.IncreaseHealth(this.AbilityPoints);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
