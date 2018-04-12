namespace P03_BarraksWars.Models.Units
{
    using _03BarracksFactory.Models.Units;
    class Gunner : Unit
    {
        private const int DefaultHealth = 25;
        private const int DefaultDamage = 7;
        public Gunner() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}
