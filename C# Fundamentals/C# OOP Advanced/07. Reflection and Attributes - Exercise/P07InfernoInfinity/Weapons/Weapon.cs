namespace P07InfernoInfinity.Weapons
{
    using P07InfernoInfinity.Contracts;
    using P07InfernoInfinity.Enums;
    using System;

    public abstract class Weapon : IWeapon
    {
        private IGem[] gems;
        protected Weapon(string weaponType, string name, int minimumDamage, int maximumDamage, int numberOfSockets)
        {
            Name = name;
            int damageIncrease = (int)Enum.Parse(typeof(Rarity), weaponType);
            MinimumDamage = minimumDamage * damageIncrease;
            MaximumDamage = maximumDamage * damageIncrease;
            NumberOfSockets = numberOfSockets;
            Strenght = 0;
            Agility = 0;
            Vitality = 0;
            gems = new IGem[NumberOfSockets];
        }

        public string Name { get; private set; }
        public int MinimumDamage { get; private set; }
        public int MaximumDamage { get; private set; }
        public int NumberOfSockets { get; private set; }
        public int Strenght { get; private set; }
        public int Agility { get; private set; }
        public int Vitality { get; private set; }

        public void AddGem(int socketIndex, IGem gem)
        {
            if (socketIndex < NumberOfSockets)
            {
                if (gems[socketIndex]!=null)
                {
                    IGem gemOnThatPlace = gems[socketIndex];
                    this.Strenght -= gemOnThatPlace.Strength;
                    this.Agility -= gemOnThatPlace.Agility;
                    this.Vitality -= gemOnThatPlace.Vitality;
                    this.MinimumDamage -= gemOnThatPlace.Strength * 2;
                    this.MaximumDamage -= gemOnThatPlace.Strength * 3;
                    this.MinimumDamage -= gemOnThatPlace.Agility;
                    this.MaximumDamage -= gemOnThatPlace.Agility * 4;
                    gems[socketIndex] = null;
                }

                gems[socketIndex] = gem;
                this.Strenght += gem.Strength;
                this.Agility += gem.Agility;
                this.Vitality += gem.Vitality;
                this.MinimumDamage += gem.Strength * 2;
                this.MaximumDamage += gem.Strength * 3;
                this.MinimumDamage += gem.Agility;
                this.MaximumDamage += gem.Agility * 4;

            }
        }

        public void RemoveGem(int socketIndex)
        {
            IGem gem = gems[socketIndex];
            this.Strenght -= gem.Strength;
            this.Agility -= gem.Agility;
            this.Vitality -= gem.Vitality;
            this.MinimumDamage -= gem.Strength * 2;
            this.MaximumDamage -= gem.Strength * 3;
            this.MinimumDamage -= gem.Agility;
            this.MaximumDamage -= gem.Agility * 4;
            gems[socketIndex] = null;
        }

        public override string ToString() => $"{this.Name}: {MinimumDamage}-{MaximumDamage} Damage, +{Strenght} Strength, +{Agility} Agility, +{Vitality} Vitality";
    }
}

