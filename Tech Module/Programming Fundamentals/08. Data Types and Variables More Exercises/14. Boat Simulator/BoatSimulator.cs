
namespace BoatSimulator
{
    using System;
    public class BoatSimulator
    {
        static void Main()
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            int sumFirstBoatMoves = 0;
            int sumSecondBoatMoves = 0;
            byte n = byte.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string move = Console.ReadLine();

                if (move == "UPGRADE")
                {
                    firstBoat = (char)(3 + firstBoat);
                    secondBoat = (char)(3 + secondBoat);
                }
                else
                {
                    if (i % 2 == 1)
                    {
                        sumFirstBoatMoves += move.Length;
                    }
                    else
                    {
                        sumSecondBoatMoves += move.Length;
                    }
                }

                if (sumFirstBoatMoves >= 50 || sumSecondBoatMoves >= 50)
                {
                    break;
                }
            }

            if (sumFirstBoatMoves > sumSecondBoatMoves)
            {
                Console.WriteLine(firstBoat);
            }
            else
            {
                Console.WriteLine(secondBoat);
            }
        }
    }
}
