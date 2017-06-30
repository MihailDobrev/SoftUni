namespace _03.Jarvis
{
    using System;
    public class ProgramEntry
    {
        static void Main()
        {
            long jarvisEnergy = long.Parse(Console.ReadLine());
            Jarvis jarvis = new Jarvis();
            jarvis.Energy = jarvisEnergy;

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens[0]=="Assemble!")
                {
                    break;
                }
                switch (tokens[0])
                {
                    case "Head":
                        Head head = new Head()
                        {
                            Energy = int.Parse(tokens[1]),
                            Iq = int.Parse(tokens[2]),
                            Material = tokens[3]
                        };
                        jarvis.addHead(head);
                        break;
                    case "Torso":
                        Torso torso = new Torso()
                        {
                            Energy = int.Parse(tokens[1]),
                            ProcessorSize = double.Parse(tokens[2]),
                            Material = tokens[3]
                        };
                        jarvis.addTorso(torso);
                        break;
                    case "Leg":
                        Leg leg = new Leg()
                        {
                            Energy = int.Parse(tokens[1]),
                            Strenght = int.Parse(tokens[2]),
                            Speed = int.Parse(tokens[3]),
                        };
                        jarvis.addLeg(leg);
                        break;
                    case "Arm":
                        Arm arm = new Arm()
                        {
                            Energy = int.Parse(tokens[1]),
                            Reach = int.Parse(tokens[2]),
                            Fingers = int.Parse(tokens[3]),
                        };
                        jarvis.addArm(arm);
                        break;
                }
            }
            Console.WriteLine(jarvis.ToString());
        }
    }
}
