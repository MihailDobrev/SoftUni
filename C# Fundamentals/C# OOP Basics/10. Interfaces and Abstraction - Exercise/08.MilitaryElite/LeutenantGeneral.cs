namespace _08.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class LeutenantGeneral:Soldier,ISoldier
    {
        public LeutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<ISoldier>();
        }

        public List<ISoldier> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append("Privates:");
            if (Privates.Count>0)
            {
                sb.AppendLine();
                sb.Append(" ");
            }
            sb.Append(string.Join(Environment.NewLine+" ", this.Privates));
            return sb.ToString();
        }
    }
}
