namespace _14.Cat_Lady
{
    using System.Text;
    public class Siamese : Cat
    {
        public Siamese(string type, string name, int earSize)
              : base(type, name)
        {
            EarSize = earSize;
        }

        public int EarSize { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Type} {this.Name} {this.EarSize}");
            return sb.ToString();
        }
    }
}
