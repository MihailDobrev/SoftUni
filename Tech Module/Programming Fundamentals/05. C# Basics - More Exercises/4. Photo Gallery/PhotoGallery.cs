

namespace _4.Photo_Gallery
{
    using System;
    using System.Globalization;

    public class PhotoGallery
    {
        static void Main()
        {
           
            short photonNumber = short.Parse(Console.ReadLine());
            byte day = byte.Parse(Console.ReadLine());
            byte month = byte.Parse(Console.ReadLine());
            short year = short.Parse(Console.ReadLine());
            byte hour= byte.Parse(Console.ReadLine());
            byte minutes = byte.Parse(Console.ReadLine());
            double photoSize = double.Parse(Console.ReadLine());
            short imageWidth = short.Parse(Console.ReadLine());
            short imageHeight = short.Parse(Console.ReadLine());
        
            DateTime dateTaken = new DateTime(year, month, day,hour,minutes,0);

            string memoryType;
            if (photoSize>=1024 && photoSize<1048576)
            {
                photoSize /=1000;
                memoryType = "KB";
            }
            else if (photoSize >= 1048576 && photoSize < 1073741824)
            {
                photoSize /= 1000000;
                memoryType = "MB";
            }
            else
            {
                memoryType = "B";
            }

            string orientationType;

            if (imageWidth>imageHeight)
            {
                orientationType="landscape";
            }
            else if (imageWidth<imageHeight)
            {
                orientationType = "portrait";
            }
            else
            {
                orientationType = "square";
            }
            
            Console.WriteLine($"Name: DSC_{photonNumber.ToString("D4")}.jpg");
            Console.WriteLine($"Date Taken: {dateTaken.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)}");
            
            Console.WriteLine($"Size: {Math.Round(photoSize,1)}{memoryType}");
            Console.WriteLine($"Resolution: {imageWidth}x{imageHeight} ({orientationType})");
        }
    }
}
