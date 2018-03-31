namespace P03.Generic_Swap_Method_Strings
{
    using P01.Generic_Box_of_String;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            IList<Box<string>> boxes=MakeBoxes();
            boxes=SwapPositions(boxes);
            PrintBoxes(boxes);                 
        }

        private static void PrintBoxes(IList<Box<string>> boxes)
        {
            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        private static IList<Box<string>> SwapPositions(IList<Box<string>> boxes)
        {
            int[] swapPositions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = swapPositions[0];
            int secondIndex = swapPositions[1];
            var firstPosition = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = firstPosition;

            return boxes;
        }

        private static IList<Box<string>> MakeBoxes()
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            IList<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < numberOfStrings; i++)
            {
                string content = Console.ReadLine();

                Box<string> box = new Box<string>(content);
                boxes.Add(box);
            }

            return boxes;
        }
    }
}
