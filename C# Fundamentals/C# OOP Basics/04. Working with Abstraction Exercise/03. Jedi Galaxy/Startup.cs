namespace _03._Jedi_Galaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[,] galaxy = FillGalaxy();
            long sumOfAllStars = SumAllCollectedStars(galaxy);
            Console.WriteLine(sumOfAllStars);
        }

        private static long SumAllCollectedStars(int[,] galaxy)
        {
            string input;
            long sumOfAllStars = 0;

            while ((input = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoStartingPosition = input
               .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

                int[] evilPowerStartingPosition = Console.ReadLine()
                  .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();

                int evilRowPosition = evilPowerStartingPosition[0];
                int evilColumnPosition = evilPowerStartingPosition[1];

                while (evilRowPosition >= 0 && evilColumnPosition >= 0)
                {
                    if (evilRowPosition >= 0 && evilRowPosition < galaxy.GetLength(0) && evilColumnPosition >= 0 && evilColumnPosition < galaxy.GetLength(1))
                    {
                        galaxy[evilRowPosition, evilColumnPosition] = 0;
                    }
                    evilRowPosition--;
                    evilColumnPosition--;
                }

                int ivoRowPosition = ivoStartingPosition[0];
                int ivoColumnPosition = ivoStartingPosition[1];

                while (ivoRowPosition >= 0 && ivoColumnPosition < galaxy.GetLength(1))
                {
                    if (ivoRowPosition >= 0 && ivoRowPosition < galaxy.GetLength(0) && ivoColumnPosition >= 0 && ivoColumnPosition < galaxy.GetLength(1))
                    {
                        sumOfAllStars += galaxy[ivoRowPosition, ivoColumnPosition];
                    }

                    ivoColumnPosition++;
                    ivoRowPosition--;
                }
            }

            return sumOfAllStars;
        }

        private static int[,] FillGalaxy()
        {
            int[] galaxyParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rowLenght = galaxyParams[0];
            int columnLeght = galaxyParams[1];

            int[,] galaxy = new int[galaxyParams[0], galaxyParams[1]];
            int fillerCounter = 0;

            for (int row = 0; row < rowLenght; row++)
            {
                for (int column = 0; column < columnLeght; column++)
                {
                    galaxy[row, column] = fillerCounter;
                    fillerCounter++;
                }
            }

            return galaxy;
        }
    }
}
