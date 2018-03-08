namespace _08.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Commando : Soldier,ISoldier
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
            Missions = new List<Mission>();
        }    

        public string Corps { get; set; }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.Append("Missions:");
            if (Missions.Count>0)
            {
                sb.AppendLine();
            }
            sb.Append(string.Join(Environment.NewLine, this.Missions));
            return sb.ToString();
        }
    }
}
