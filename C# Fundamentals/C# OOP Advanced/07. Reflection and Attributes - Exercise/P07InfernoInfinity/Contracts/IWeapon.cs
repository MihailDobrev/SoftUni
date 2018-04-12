using P07InfernoInfinity.Weapons;

namespace P07InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        string Name { get; }
        int MinimumDamage { get; }
        int MaximumDamage { get; }
        int NumberOfSockets { get; }
        int Strenght { get; }
        int Agility { get; }
        int Vitality { get; }
        void AddGem(int socketIndex, IGem gem);
        void RemoveGem(int index);
    }
}
