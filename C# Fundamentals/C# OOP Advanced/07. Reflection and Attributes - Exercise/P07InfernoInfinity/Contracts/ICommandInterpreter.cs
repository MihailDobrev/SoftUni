namespace P07InfernoInfinity.Contracts
{
    public interface ICommandInterpreter
    {
        string InterpretCommand(string[] commandArgs);
    }
}
