namespace _5.Word_in_Plural
{
    using System;
    public class WordinPlural
    {
        static void Main()
        {
            string noun = Console.ReadLine();
            string manipulated;

            if (noun.EndsWith("y"))
            {
                manipulated = noun.Remove(noun.Length - 1, 1);
                noun = manipulated.Insert(noun.Length - 1, "ies");
            }
            else if (noun.EndsWith("o") ||
                noun.EndsWith("s") ||
                noun.EndsWith("x") ||
                noun.EndsWith("z") || 
                noun.EndsWith("ch") ||
                noun.EndsWith("sh"))
            {
                noun = noun.Insert(noun.Length, "es");
            }
            else
            {
                noun = noun.Insert(noun.Length, "s");
            }

            Console.WriteLine(noun);
        }
    }
}
