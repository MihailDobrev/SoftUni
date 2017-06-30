namespace _03.Jarvis
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class Jarvis
    {
        public long Energy { get; set; } 
        public Head Head { get; set; }
        public Torso Torso { get; set; }
        public List<Arm> Arms { get; set; }
        public List<Leg> Legs { get; set; }

        public void addHead(Head headInput)
        {
            if (Head == null)
            {
                Head = headInput;
            }
            if (headInput.Energy < Head.Energy)
            {
                Head = headInput;
            }
        }

        public void addTorso(Torso torsoInput)
        {
            if (Torso==null)
            {
                Torso = torsoInput;
            }
            if (torsoInput.Energy < Torso.Energy)
            {
                Torso = torsoInput;
            }
        }

        public void addArm(Arm arm)
        {
            if (Arms==null)
            {
                Arms = new List<Arm>();
            }
            if (Arms.Count < 2)
            {
                Arms.Add(arm);
            }
            else
            {
                for (int i = 0; i < this.Arms.Count; i++)
                {
                    if (Arms[i].Energy > arm.Energy)
                    {
                        Arms.RemoveAt(i);
                        Arms.Add(arm);
                    }
                }
            }
        }
        public void addLeg(Leg leg)
        {
            if (Legs == null)
            {
                Legs = new List<Leg>();
            }
            if (Legs.Count < 2)
            {
                Legs.Add(leg);
            }
            else
            {
                for (int i = 0; i < this.Legs.Count; i++)
                {
                    if (Legs[i].Energy > leg.Energy)
                    {
                        Legs.RemoveAt(i);
                        Legs.Add(leg);
                    }
                }
            }
        }

        public override string ToString()
        {
            if (Head == null || Torso == null || Arms.Count < 2 || Legs.Count < 2)
            {
                return "We need more parts!";
            }
            long totalEnergy = 0L;
            totalEnergy += Head.Energy;
            totalEnergy += Torso.Energy;
            totalEnergy += Arms.Select(a => long.Parse(a.Energy.ToString())).Sum();
            totalEnergy += Legs.Select(a => long.Parse(a.Energy.ToString())).Sum();

            if (totalEnergy>Energy)
            {
                return "We need more power!";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("Jarvis:\r\n");
            sb.Append(Head.ToString());
            sb.Append(Torso.ToString());

            foreach(Arm arm in Arms.OrderBy(a=>a.Energy))
            {
                sb.Append(arm.ToString());
            }

            foreach(Leg leg in Legs.OrderBy(a=>a.Energy))
            {
                sb.Append(leg.ToString());
            }
            return sb.ToString();
        }
    }
}
