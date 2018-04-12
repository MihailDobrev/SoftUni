namespace P07InfernoInfinity.Factories
{
    using P07InfernoInfinity.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory:IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponRarity,string weaponType, string weaponName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == weaponType);

            IWeapon weapon = (IWeapon)Activator.CreateInstance(type, new object[] {weaponRarity, weaponName});
            return weapon;
        }

    }
}
