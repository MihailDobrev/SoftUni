namespace _03.Jarvis
{
    class Leg
    {
        public int Energy { get; set; }
        public int Strenght { get; set; }
        public int Speed { get; set; }

        public override string ToString()
        {
            string result = "";
            result += "#Leg:\r\n";
            result += "###Energy consumption: " + Energy + "\r\n";
            result += string.Format($"###Strength: {Strenght}\r\n");
            result += string.Format($"###Speed: {Speed}\r\n");
            return result;
        }
    }
}
