namespace _02._Line_Numbers
{
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            StreamReader reader = new StreamReader("../Resources/text.txt");
            StreamWriter writer = new StreamWriter("output.txt");

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int lineCounter = 0;

                    while (line!=null)
                    {
                        lineCounter++;
                        writer.WriteLine($"Line {lineCounter}:{line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
