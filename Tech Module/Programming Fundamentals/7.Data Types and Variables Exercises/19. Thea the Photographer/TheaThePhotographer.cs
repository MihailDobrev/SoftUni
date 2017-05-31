
namespace _19.Thea_the_Photographer
{
    using System;
    public class TheaThePhotographer
    {
        static void Main()
        {
            long amountOfPictures = long.Parse(Console.ReadLine());
            long filterTimePerPic = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTimePerPic = long.Parse(Console.ReadLine());

            long filteredPictures = (long)(Math.Ceiling(amountOfPictures * filterFactor / 100.00));
            double filterTimeAllPics = amountOfPictures * filterTimePerPic;
            double uploadTimeAllPics = uploadTimePerPic * filteredPictures;
            double totalTime = filterTimeAllPics + uploadTimeAllPics;

            TimeSpan projectTime = TimeSpan.FromSeconds(totalTime);
            string seconds = string.Format("{0}:{1:D2}:{2:D2}:{3:D2}", projectTime.Days, projectTime.Hours, projectTime.Minutes, projectTime.Seconds);
            Console.WriteLine(seconds);
            
        }
    }
}
