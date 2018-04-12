namespace P08_CreateCustomClassAttribute
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            Type testAttribute = typeof(Weapon);
            object atribute = testAttribute.GetCustomAttributes(false).FirstOrDefault();
            WeaponAttribute atr = (WeaponAttribute)atribute;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                Console.WriteLine(atr.PrintInfo(input));
            }
        }
    }
}
