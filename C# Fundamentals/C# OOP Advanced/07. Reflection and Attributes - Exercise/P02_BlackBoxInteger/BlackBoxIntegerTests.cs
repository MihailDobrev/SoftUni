namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            // we get all constructors
            ConstructorInfo[] constructorsInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

            //we make an instance of an object from the needed constructor
            object blackBoxIntegerObject = constructorsInfo[1].Invoke(new object[] { });

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split('_');
                string commandName = commandArgs[0];
                int commandParameter = int.Parse(commandArgs[1]);

                switch (commandName)
                {
                    case "Add":
                        InvokeMethodAndPrintValue("Add", commandParameter, type, blackBoxIntegerObject);
                        break;
                    case "Subtract":
                        InvokeMethodAndPrintValue("Subtract", commandParameter, type, blackBoxIntegerObject);
                        break;
                    case "Divide":
                        InvokeMethodAndPrintValue("Divide", commandParameter, type, blackBoxIntegerObject);
                        break;
                    case "Multiply":
                        InvokeMethodAndPrintValue("Multiply", commandParameter, type, blackBoxIntegerObject);
                        break;
                    case "RightShift":
                        InvokeMethodAndPrintValue("RightShift", commandParameter, type, blackBoxIntegerObject);
                        break;
                    case "LeftShift":
                        InvokeMethodAndPrintValue("LeftShift", commandParameter, type, blackBoxIntegerObject);
                        break;
                }
            }
        }

        public static void InvokeMethodAndPrintValue(string methodName, int numberAsParameter, Type type, object blackBoxIntegerObject)
        {

            //we find the method needed
            MethodInfo method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            
            //we invoke the method
            method.Invoke(blackBoxIntegerObject, new object[] { numberAsParameter });

            Object fieldInfo = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(blackBoxIntegerObject);

            Console.WriteLine(fieldInfo);
        }
    }
}
