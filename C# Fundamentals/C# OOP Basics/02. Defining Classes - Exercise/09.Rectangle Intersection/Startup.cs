namespace _09.Rectangle_Intersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Startup
    {
        static void Main()
        {
            double[] rectangleParams = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double totalRectangles = rectangleParams[0];
            double intersectionChecks = rectangleParams[1];
            Dictionary<string, Rectangle> rectangles = new Dictionary<string, Rectangle>();
            for (int line = 0; line < totalRectangles; line++)
            {
                string[] rectangleArgs = Console.ReadLine().Split();
                string id = rectangleArgs[0];
                double width = double.Parse(rectangleArgs[1]);
                double height = double.Parse(rectangleArgs[2]);
                double topLeftCornerHorizontal = double.Parse(rectangleArgs[3]);
                double TopLeftCornerVertical = double.Parse(rectangleArgs[4]);
                Rectangle rectangle = new Rectangle(id,width,height,topLeftCornerHorizontal,TopLeftCornerVertical);
                rectangles.Add(id, rectangle);
            }
            
            for (int i = 0; i < intersectionChecks; i++)
            {
                string[] ids = Console.ReadLine().Split();

                string currentRectangleID = ids[0];
                string nextRectangleID = ids[1];
                
                bool doesIntersect = rectangles[currentRectangleID].DoesIntersect(rectangles[nextRectangleID]);
                Console.WriteLine(doesIntersect.ToString().ToLower());
            }
        }
    }
}
