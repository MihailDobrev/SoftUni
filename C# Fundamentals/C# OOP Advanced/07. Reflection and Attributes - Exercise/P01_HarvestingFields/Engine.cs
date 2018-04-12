namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            string command;
            Type type = typeof(HarvestingFields);

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                switch (command)
                {
                    case "private":
                        fieldsInfo = fieldsInfo.Where(f => f.IsPrivate == true).ToArray();
                        PrintOutput(fieldsInfo);
                        break;
                    case "protected":
                        fieldsInfo = fieldsInfo.Where(f => f.IsFamily == true).ToArray();
                        PrintOutput(fieldsInfo);
                        break;
                    case "public":
                        fieldsInfo = fieldsInfo.Where(f => f.IsPublic == true).ToArray();
                        PrintOutput(fieldsInfo);
                        break;
                    case "all":
                        PrintOutput(fieldsInfo);
                        break;
                }
            }
        }

        private static void PrintOutput(FieldInfo[] fieldsInfo)
        {
            foreach (var fieldInfo in fieldsInfo)
            {
                string accessModifier = fieldInfo.Attributes.ToString() == "Family" ? "protected" : fieldInfo.Attributes.ToString().ToLower();
                Console.WriteLine($"{accessModifier} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
            }
        }
    }
}