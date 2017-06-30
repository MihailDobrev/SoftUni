namespace _03.Jarvis
{
    class Arm
    {
        public int Energy { get; set; }
        public int Reach { get; set; }
        public int Fingers { get; set; }

        public override string ToString()
        {
            string result = "";
            result += "#Arm:\r\n";
            result += "###Energy consumption: " + Energy + "\r\n";
            result += string.Format($"###Reach: {Reach}\r\n");
            result += string.Format($"###Fingers: {Fingers}\r\n");

            return result;
        }
    }
}
