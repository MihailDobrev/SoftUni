namespace _07.Predicate_for_names
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            int nameLenght = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < names.Length; index++)
            {
                string currentName = names[index];

                if (IsLenghtLessOrEqual(currentName, n=>n.Length<=nameLenght))
                {
                    Console.WriteLine(currentName);
                }
            }
        }
        public static bool IsLenghtLessOrEqual(string name, Func<string, bool> condition) => condition(name);
        
    }
}
