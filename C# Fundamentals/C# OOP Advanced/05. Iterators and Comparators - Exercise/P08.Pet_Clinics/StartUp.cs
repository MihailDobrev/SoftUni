namespace P08.Pet_Clinics
{
    using System;
    using System.Linq;
    public class StartUp
    {
        public static void Main()
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();
            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToArray();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            string objectToCreate = commandArgs[0];
                            if (objectToCreate == "Pet")
                            {
                                commandInterpreter.CreatePet(commandArgs[1], int.Parse(commandArgs[2]), commandArgs[3]);
                            }
                            else if (objectToCreate == "Clinic")
                            {
                                commandInterpreter.CreateClinic(commandArgs[1], int.Parse(commandArgs[2]));
                            }
                            break;
                        case "Add":
                            Console.WriteLine(commandInterpreter.Add(commandArgs[0], commandArgs[1]));
                            break;
                        case "Release":
                            Console.WriteLine(commandInterpreter.Release(commandArgs[0]));
                            break;
                        case "HasEmptyRooms":
                            Console.WriteLine(commandInterpreter.HasEmptyRooms(commandArgs[0]));
                            break;
                        case "Print":
                            if (commandArgs.Length == 1)
                            {
                                commandInterpreter.Print(commandArgs[0]);
                            }
                            else if (commandArgs.Length == 2)
                            {
                                commandInterpreter.Print(commandArgs[0], int.Parse(commandArgs[1]));
                            }                    
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
              
            }
        }
    }
}
