namespace _14.Cat_Lady
{
    using System.Text;
    public class StreetExtraordinaire : Cat
    {
        public StreetExtraordinaire(string type, string name, int decibelsOfMeows)
             : base(type, name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Type} {this.Name} {this.DecibelsOfMeows}");
            return sb.ToString();
        }
    }
}
