namespace _05.Write_to_File
{
    using System;
    using System.IO;
    public class WriteToFile
    {
        static void Main()
        {
            var textInFile = File.ReadAllText("sample_text.txt").Split(new char[] {',','.','!',':','?' },StringSplitOptions.RemoveEmptyEntries);
            string text = string.Join("", textInFile);
            File.WriteAllText("output.txt", text);
        }
    }
}
