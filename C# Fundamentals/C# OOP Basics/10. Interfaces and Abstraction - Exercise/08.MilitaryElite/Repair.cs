namespace _08.MilitaryElite
{
    public class Repair
    {
        public Repair(string part, string hours)
        {
            Part = part;
            Hours = hours;
        }

        public string Part { get; set; }

        public string Hours { get; set; }

        public override string ToString()
        {
            return $" Part Name: {this.Part} Hours Worked: {this.Hours}";
        }
    }
}
