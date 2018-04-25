namespace DungeonsAndCodeWizards.Characters
{
    using DungeonsAndCodeWizards.Bags;
    using DungeonsAndCodeWizards.Contracts;
    using DungeonsAndCodeWizards.Enums;
    using System;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, 100, 50, 40, new Satchel(), faction)
        {
            this.BaseHealth = 100;
            this.BaseArmor = 50;
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }
                if (this.Faction == character.Faction)
                {
                    throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
                }
                character.TakeDamage(this.AbilityPoints);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
