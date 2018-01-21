namespace _01.Define_a_Class_Person
{
    using System;
    using System.Reflection;
    public class Startup
    {
        static void Main()
        {
            Type personType = typeof(Person);
            FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);
        }
    }
}
