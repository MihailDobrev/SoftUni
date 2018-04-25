namespace DungeonsAndCodeWizards.Contracts
{
    using DungeonsAndCodeWizards.Characters;

    public interface IAttackable
    {
        void Attack(Character character);
    }
}
