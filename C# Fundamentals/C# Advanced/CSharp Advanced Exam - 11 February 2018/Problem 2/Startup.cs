namespace Problem_2
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            char[][] room = new char[numberOfRows][];

            for (int row = 0; row < numberOfRows; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }

            char[] directionSequence = Console.ReadLine().ToCharArray();
            Queue<char> directions = new Queue<char>();

            for (int index = 0; index < directionSequence.Length; index++)
            {
                directions.Enqueue(directionSequence[index]);
            }

            int roomColumnsPerRow = 0;
            bool playerKilled = false;
            bool nikoladzeKilled = false;
            int playerRowPosition = 0;
            int playerColumnPosition = 0;


            while (true)
            {
                for (int row = 0; row < room.GetLength(0); row++)
                {
                    roomColumnsPerRow = room[row].Length;

                    for (int column = 0; column < room[row].Length; column++)
                    {
                        char enemyType = ' ';

                        //Enemies move
                        if (room[row][column] == 'b')
                        {
                            enemyType = 'b';
                            if (column + 1 < room[row].Length)
                            {
                                room[row][column + 1] = 'b';
                                room[row][column] = '.';
                            }
                            else if (column + 1 == room[row].Length)
                            {
                                room[row][column] = 'd';
                                enemyType = 'd';
                            }
                        }
                        else if (room[row][column] == 'd')
                        {
                            enemyType = 'd';
                            if (column - 1 >= 0)
                            {
                                room[row][column - 1] = 'd';
                                room[row][column] = '.';
                            }
                            else if (column - 1 < 0)
                            {
                                room[row][column] = 'b';
                                enemyType = 'b';
                            }
                        }
                        else if (room[row][column] == 'S')
                        {
                            playerRowPosition = row;
                            playerColumnPosition = column;
                        }


                        //Check if Sam will be killed

                        if (enemyType == 'b')
                        {
                            for (int checkingColumnIndex = column; checkingColumnIndex < roomColumnsPerRow; checkingColumnIndex++)
                            {
                                if (room[row][checkingColumnIndex] == 'S')
                                {
                                    playerKilled = true;
                                    room[row][checkingColumnIndex] = 'X';
                                    break;
                                }
                            }
                        }
                        else if (enemyType == 'd')
                        {
                            for (int checkingColumnIndex = column; checkingColumnIndex >= 0; checkingColumnIndex--)
                            {
                                if (room[row][checkingColumnIndex] == 'S')
                                {
                                    playerKilled = true;
                                    room[row][checkingColumnIndex] = 'X';
                                    break;
                                }
                            }
                        }

                        if (enemyType == 'b')
                        {
                            break;
                        }
                    }

                }

                if (playerKilled)
                {
                    break;
                }

                //Move the player Sam according to the direction

                char direction = directions.Dequeue();

                switch (direction)
                {
                    case 'U':
                        room[playerRowPosition - 1][playerColumnPosition] = 'S';
                        room[playerRowPosition][playerColumnPosition] = '.';
                        playerRowPosition--;
                        break;
                    case 'D':
                        room[playerRowPosition + 1][playerColumnPosition] = 'S';
                        room[playerRowPosition][playerColumnPosition] = '.';
                        playerRowPosition++;
                        break;
                    case 'L':
                        room[playerRowPosition][playerColumnPosition - 1] = 'S';
                        room[playerRowPosition][playerColumnPosition] = '.';
                        playerColumnPosition--;
                        break;
                    case 'R':
                        room[playerRowPosition][playerColumnPosition + 1] = 'S';
                        room[playerRowPosition][playerColumnPosition] = '.';
                        playerColumnPosition++;
                        break;
                    default:
                        break;
                }

                // Check if Sam is being face to face with an enemy


                for (int column = playerColumnPosition + 1; column < roomColumnsPerRow; column++)
                {
                    if (room[playerRowPosition][column] == 'd')
                    {
                        playerKilled = true;
                        room[playerRowPosition][playerColumnPosition] = 'X';
                        break;
                    }
                }

                if (playerKilled)
                {
                    break;
                }

                for (int column = playerColumnPosition - 1; column >= 0; column--)
                {
                    if (room[playerRowPosition][column] == 'b')
                    {
                        playerKilled = true;
                        room[playerRowPosition][playerColumnPosition] = 'X';
                        break;
                    }
                }

                if (playerKilled)
                {
                    break;
                }

                //Check if Sam kills Nikoladze

                for (int column = 0; column < roomColumnsPerRow; column++)
                {
                    if (room[playerRowPosition][column] == 'N')
                    {
                        room[playerRowPosition][column] = 'X';
                        nikoladzeKilled = true;
                    }
                }

                if (nikoladzeKilled)
                {
                    break;
                }       

            }

            if (playerKilled)
            {
                Console.WriteLine($"Sam died at {playerRowPosition}, {playerColumnPosition}");
            }
            else if (nikoladzeKilled)
            {
                Console.WriteLine("Nikoladze killed!");
            }
            PrintRoom(room);
        }

        private static void PrintRoom(char[][] room)
        {
            for (int row = 0; row < room.GetLength(0); row++)
            {
                for (int column = 0; column < room[row].Length; column++)
                {
                    Console.Write(room[row][column]);
                }
                Console.WriteLine();
            }
          
        }
    }
}
