namespace _03.Jarvis
{
    public class Torso
    {
        public long Energy { get; set; }
        public double ProcessorSize { get; set; }
        public string Material { get; set; }
        public override string ToString()
        {
            string result = "";
            result += "#Torso:\r\n";
            result += "###Energy consumption: " + Energy + "\r\n";
            result += string.Format($"###Processor size: {ProcessorSize:F1}\r\n");
            result += string.Format($"###Corpus material: {Material}\r\n");
            return result;
        }
    }
}
