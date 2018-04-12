namespace P07InfernoInfinity.Data
{
    using P07InfernoInfinity.Contracts;
    using P07InfernoInfinity.Weapons;
    using System.Collections.Generic;
    using System.Linq;

    public class WeaponRepository : IRepository
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public void CreateWeapon(IWeapon weapon)
        {
            weapons.Add(weapon);
        }
        public void AddGem(string weapon, int index, IGem gem)
        {
            IWeapon searchedWeapon = weapons.First(w => w.Name == weapon);
            searchedWeapon.AddGem(index, gem);
        }

        public void RemoveGem(string weaponName,int index)
        {
            IWeapon searchedWeapon = weapons.First(w => w.Name == weaponName);
            searchedWeapon.RemoveGem(index);
        }

        public string Print(string weaponName)
        {
            IWeapon searchedWeapon = weapons.First(w => w.Name == weaponName);
            return searchedWeapon.ToString();
        }
    }
}
