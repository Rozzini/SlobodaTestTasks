using System;
using System.Collections.Generic;
using System.Text;

namespace Sloboda_friends
{
    class Grid
    {
        //function for output array
        public static void DrawGrid(int[,] friendsGrid, int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < N; j++)
                {
                    Console.Write(friendsGrid[i, j] + " ");
                }
            }
        }


        //function for array generation
        public static int[,] GridGenerator(int N)
        {
            int[,] friendsGrid = new int[N, N];

            Random random = new Random();

            //throw random numbers on the grid (from 0 to 1)
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    friendsGrid[i, j] = random.Next(0, 2);
                }
            }

            //checking for the issue if person is in friendship with himself, and if person thinks that other one is his friend, but this is not true
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //if person accidentaly become friend with himself, set to 0
                    if (i == j)
                    {
                        friendsGrid[i, j] = 0;
                    }

                    //check if person suffer from unrequited friendship
                    else if (friendsGrid[j, i] == 0)
                    {
                        friendsGrid[i, j] = 0;
                    }
                }
            }
            return friendsGrid;
        }
    }
}
