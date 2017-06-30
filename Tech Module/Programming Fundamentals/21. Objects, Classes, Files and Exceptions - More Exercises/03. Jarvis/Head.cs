namespace _03.Jarvis
{
    class Head
    {
        public long Energy { get; set; }
        public int Iq { get; set; }
        public string Material { get; set; }

        public override string ToString()
        {
            string result = "";
            result += "#Head:\r\n";
            result += "###Energy consumption: " + Energy + "\r\n";
            result += string.Format($"###IQ: {Iq}\r\n");
            result += string.Format($"###Skin material: {Material} \r\n");
            return result;
        }
    }
}
