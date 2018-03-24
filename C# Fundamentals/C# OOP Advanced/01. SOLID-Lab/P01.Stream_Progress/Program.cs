namespace P01.Stream_Progress
{
    using System;
    public class Program
    {
        static void Main()
        {
            StreamProgressInfo streamProgressInfo = new StreamProgressInfo(new File("file", 100, 1000));
            StreamProgressInfo streamProgressInfo2 = new StreamProgressInfo(new Music("musician", "album", 10, 100));
            Console.WriteLine(streamProgressInfo.CalculateCurrentPercent());
            Console.WriteLine(streamProgressInfo2.CalculateCurrentPercent());
        }
    }
}
