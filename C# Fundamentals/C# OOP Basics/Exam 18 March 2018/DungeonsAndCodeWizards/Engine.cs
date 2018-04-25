namespace DungeonsAndCodeWizards
{
    using System;
    using System.Linq;

    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToArray();
                string output = string.Empty;
                bool isGameOver = false;

                try
                {
                    switch (commandName)
                    {
                        case "JoinParty":
                            output = dungeonMaster.JoinParty(commandArgs);
                            break;
                        case "AddItemToPool":
                            output = dungeonMaster.AddItemToPool(commandArgs);
                            break;
                        case "PickUpItem":
                            output = dungeonMaster.PickUpItem(commandArgs);
                            break;
                        case "UseItem":
                            output = dungeonMaster.UseItem(commandArgs);
                            break;
                        case "UseItemOn":
                            output = dungeonMaster.UseItemOn(commandArgs);
                            break;
                        case "GiveCharacterItem":
                            output = dungeonMaster.GiveCharacterItem(commandArgs);
                            break;
                        case "GetStats":
                            output = dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            output = dungeonMaster.Attack(commandArgs);
                            break;
                        case "Heal":
                            output = dungeonMaster.Heal(commandArgs);
                            break;
                        case "EndTurn":
                            output = dungeonMaster.EndTurn(commandArgs);
                            isGameOver = dungeonMaster.isGameOver;
                            break;
                        case "IsGameOver":
                            isGameOver = dungeonMaster.IsGameOver();
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(output);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Parameter Error: " + ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation: " + ioe.Message);
                }

                if (isGameOver)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            PrintFinalStats();
        }

        private void PrintFinalStats()
        {
            string result = dungeonMaster.GetStats();
            Console.WriteLine("Final stats:");
            Console.WriteLine(result);
        }
    }
}