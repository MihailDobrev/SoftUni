namespace P04.Generic_Swap_Method_Integer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P01.Generic_Box_of_String;

    public class StartUp
    {
        public static void Main()
        {
            IList<Box<int>> boxes = MakeBoxes();
            boxes = SwapPositions(boxes);
            PrintBoxes(boxes);
        }

        private static void PrintBoxes(IList<Box<int>> boxes)
        {
            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        private static IList<Box<int>> SwapPositions(IList<Box<int>> boxes)
        {
            int[] swapPositions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = swapPositions[0];
            int secondIndex = swapPositions[1];
            var firstPosition = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = firstPosition;

            return boxes;
        }

        private static IList<Box<int>> MakeBoxes()
        {
            int numberOfStrings = int.Parse(Console.ReadLine());
            IList<Box<int>> boxes = new List<Box<int>>();

            for (int i = 0; i < numberOfStrings; i++)
            {
                string content = Console.ReadLine();

                Box<int> box = new Box<int>(int.Parse(content));
                boxes.Add(box);
            }

            return boxes;
        }
    }
}
