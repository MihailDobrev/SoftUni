namespace DungeonsAndCodeWizards.Characters
{
    using DungeonsAndCodeWizards.Bags;
    using DungeonsAndCodeWizards.Enums;
    using DungeonsAndCodeWizards.Items;
    using System;

    public abstract class Character
    {
        #region Fields
        private string name;
        private double health;
        private double armor;

        #endregion

        #region Constructors
        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
            RestHealMultiplier = 0.2;

        }
        #endregion

        #region Properties
        public double BaseArmor { get; protected set; }
        public double BaseHealth { get; protected set; }
        public double AbilityPoints { get; protected set; }
        public Bag Bag { get; protected set; }
        public virtual double RestHealMultiplier { get; protected set; }
        public Faction Faction { get; protected set; }
        public bool IsAlive { get; protected set; }
        public double Health
        {
            get { return health; }
            protected set
            {
                if (value <= this.BaseHealth || value >= 0)
                {
                    health = value;
                }
            }
        }
        public double Armor
        {
            get { return armor; }
            protected set
            {
                if (value <= this.BaseArmor || value >= 0)
                {
                    armor = value;
                }
            }
        }
        public string Name
        {
            get { return name; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        #endregion

        #region Methods
        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                if (Armor > hitPoints)
                {
                    Armor -= hitPoints;
                }
                else
                {
                    this.health -= hitPoints - Armor;
                    Armor = 0;

                    if (health <= 0)
                    {
                        health = 0;
                        this.IsAlive = false;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                health += BaseHealth * RestHealMultiplier;
                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                item.AffectCharacter(character);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                character.Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void ReceiveItem(Item item)
        {
            if (this.IsAlive)
            {
                this.Bag.AddItem(item);
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void IncreaseHealth(double abilityPoints)
        {
            if (this.IsAlive)
            {
                health += abilityPoints;
                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void RestoreArmor()
        {
            if (this.IsAlive)
            {
                this.Armor = BaseArmor;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void DecreaseHealth(int decrease)
        {
            this.Health -= decrease;
            if (health <= 0)
            {
                health = 0;
                this.IsAlive = false;
            }

        }
        #endregion
        

    }
}
