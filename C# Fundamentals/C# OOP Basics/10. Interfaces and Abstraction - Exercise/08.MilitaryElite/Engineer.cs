namespace _08.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Engineer : Soldier,ISoldier
    {
        public Engineer(int id, string firstName, string lastName, decimal salary,string corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
            Repairs = new List<Repair>();
        }

        public string Corps { get; set; }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.Append("Repairs:");
            if (Repairs.Count>0)
            {
                sb.AppendLine();
            }
            sb.Append(string.Join(Environment.NewLine, this.Repairs));
            return sb.ToString();
        }
    }
}
