namespace P07InfernoInfinity.Contracts
{
    using P07InfernoInfinity.Weapons;
    public interface IRepository
    {
        void CreateWeapon(IWeapon weapon);
        void AddGem(string weapon, int index, IGem gem);
        void RemoveGem(string weaponName, int index);
        string Print(string weaponName);
    }
}
