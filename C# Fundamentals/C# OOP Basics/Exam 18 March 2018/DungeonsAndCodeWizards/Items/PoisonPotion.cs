namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;

    public class PoisonPotion : Item
    {
        public PoisonPotion() 
            : base(5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.DecreaseHealth(20);
        }
    }
}
