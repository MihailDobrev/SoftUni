using System.Text;
public class Seat : ICar
{
    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public string Model { get; set; }
    public string Color { get; set; }
    public int Start { get; set; }
    public string Stop { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
        sb.AppendLine("Engine start");
        sb.Append("Breaaak!");

        return sb.ToString();
    }
}

