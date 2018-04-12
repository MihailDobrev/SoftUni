namespace P07InfernoInfinity
{
    using P07InfernoInfinity.Enums;
    using P07InfernoInfinity.Weapons;
    using System;

    public abstract class Gem : IGem
    {
        protected Gem(string type, int strength, int agility, int vitality)
        {
            int statIncrease = (int)Enum.Parse(typeof(Clarity), type);
            Strength = strength + statIncrease;
            Agility = agility + statIncrease;
            Vitality = vitality + statIncrease;
        }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Vitality { get; private set; }
    }
}
