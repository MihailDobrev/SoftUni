namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;

    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() 
            : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.RestoreArmor();
        }
    }
}
