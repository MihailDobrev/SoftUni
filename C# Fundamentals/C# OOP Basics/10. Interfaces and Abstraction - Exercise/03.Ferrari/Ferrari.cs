namespace _03.Ferrari
{
    public class Ferrari:ICar
    {
        public Ferrari(string driver)
        {
            Model = "488-Spider";
            Driver = driver;
        }

        public string Model { get; }
        public string Driver { get; private set; }

        public string UseBrakes() => "Brakes!";

        public string PushTheGas() => "Zadu6avam sA!";

        public override string ToString() => $"488-Spider/{UseBrakes()}/{PushTheGas()}/{this.Driver}";
    }
}
