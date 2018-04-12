namespace P07InfernoInfinity.Factories
{
    using P07InfernoInfinity.Contracts;
    using P07InfernoInfinity.Weapons;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory:IGemFactory
    {
        public IGem CreateGem(string gemType, string gemName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == gemName);

            IGem gem = (IGem)Activator.CreateInstance(type, new object[] {gemType});

            return gem;
        }
    }
}
