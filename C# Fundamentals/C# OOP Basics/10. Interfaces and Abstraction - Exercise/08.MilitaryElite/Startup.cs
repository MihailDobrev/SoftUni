namespace _08.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            List<ISoldier> soldiers = ReadSoldiers();
            PrintSoldiers(soldiers);
        }

        private static void PrintSoldiers(List<ISoldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }

        private static List<ISoldier> ReadSoldiers()
        {
            List<ISoldier> soldiers = new List<ISoldier>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] soldierInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (soldierInfo[0])
                {
                    case "Private":
                        soldiers.Add(new Private(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4])));
                        break;
                    case "LeutenantGeneral":
                        LeutenantGeneral general = new LeutenantGeneral(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4]));
                        for (int index = 5; index < soldierInfo.Length; index ++)
                        {
                            var privat = soldiers.First(s => s.Id == int.Parse(soldierInfo[index]));
                            general.Privates.Add(privat);
                        }
                        soldiers.Add(general);
                        break;
                    case "Engineer":
                        if (soldierInfo[5]!= "Airforces" && soldierInfo[5]!="Marines")
                        {
                            continue;
                        }
                        Engineer engineer = new Engineer(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4]),soldierInfo[5]);

                        for (int index = 6; index < soldierInfo.Length; index+=2)
                        {
                            engineer.Repairs.Add(new Repair(soldierInfo[index], soldierInfo[index + 1]));
                        }
                        soldiers.Add(engineer);                   
                        break;
                    case "Commando":
                        if (soldierInfo[5] != "Airforces" && soldierInfo[5] != "Marines")
                        {
                            continue;
                        }
                        Commando commando = new Commando(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4]), soldierInfo[5]);
                        for (int index = 6; index < soldierInfo.Length; index += 2)
                        {
                            if (soldierInfo[index + 1] == "inProgress" || soldierInfo[index + 1] == "Finished")
                            {
                                commando.Missions.Add(new Mission(soldierInfo[index], soldierInfo[index + 1]));
                            }                       
                        }
                        soldiers.Add(commando);

                        break;

                    case "Spy":
                        Spy spy = new Spy(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], long.Parse(soldierInfo[4]));                       
                        soldiers.Add(spy);
                        break;
                    default:
                        break;
                }
            }
            return soldiers;
        }
    }
}
