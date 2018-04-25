namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;
    using System;

    public abstract class Item
    {
        public string Name => this.GetType().Name;
        public int Weight { get; protected set; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }
        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }
    }
}
