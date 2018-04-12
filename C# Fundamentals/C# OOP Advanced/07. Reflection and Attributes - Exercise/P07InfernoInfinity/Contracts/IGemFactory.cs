namespace P07InfernoInfinity.Contracts
{
    using P07InfernoInfinity.Weapons;

    public interface IGemFactory
    {
        IGem CreateGem(string gemType, string gemName);
    }
}
