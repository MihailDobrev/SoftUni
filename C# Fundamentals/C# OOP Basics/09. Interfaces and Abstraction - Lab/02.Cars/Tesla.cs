using System.Text;
public class Tesla : IElectricCar, ICar
{
    public Tesla(string model, string color, int batteries)
    {
        Batteries = batteries;
        Model = model;
        Color = color;
    }

    public int Batteries { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Start { get; set; }
    public string Stop { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Batteries} Batteries");
        sb.AppendLine("Engine start");
        sb.Append("Breaaak!");

        return sb.ToString();
    }
}
