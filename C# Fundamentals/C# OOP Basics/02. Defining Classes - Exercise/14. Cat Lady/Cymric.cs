namespace _14.Cat_Lady
{
    using System.Text;
    public class Cymric:Cat
    {
        public Cymric(string type, string name, double furLength)
             : base(type, name)
        {
            this.FurLength = furLength;
        }

        public double FurLength { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Type} {this.Name} {this.FurLength:F2}");
            return sb.ToString();
        }
    }
}
