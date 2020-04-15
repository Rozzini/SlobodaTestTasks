using System;
using System.Collections.Generic;
using System.Linq;

namespace Sloboda_friends
{
    class Program
    {
        public static void Main()
        {
            bool Pass = false;
            int N = Validation('N');
            int S = Validation('S');
            do
            {
                if (S < N) Pass = true;
                else S = Validation('S');
            }
            while (Pass == false); ;

            int[,] FriendsGrid = GridGenerator(N);
            //int[,] FriendsGrid =  {{0, 1, 0},
            //                       {1, 0, 1},
            //                       {0, 1, 0}};
            DrawGrid(FriendsGrid, 5);
            Console.WriteLine("\nResult: " + FindFriends(S, FriendsGrid, N));

        }


        static int Validation(char Symbol)
        {
            bool Validation = true;
            string input;
            int Grams = 0;
            while (!Validation == false)
            {
                Console.Write(Symbol + "= ");
                input = Console.ReadLine();
                if (int.TryParse(input, out Grams))
                {
                    Validation = false;
                }

                //added this to avoid stack overflow
                if (Grams <= 0)
                {
                    Console.WriteLine("please input valid number");
                    Validation = true;
                }
            }
            return Grams;
        }

        static void DrawGrid(int[,] friendsGrid, int N)
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
       static int FindFriends(int S, int[,] friendsGrid, int N)
        {
            int FriendsCounter = 0 ;
            int IntersectionsCounter = 0;
            Stack<int> PersonsToCheck = new Stack<int>();
            List<int> CheckedPersons = new List<int>();
            
            for(int i = 0; i<N; i++)
            {
                if(friendsGrid[S,i] == 1)
                {
                    PersonsToCheck.Push(i);
                    IntersectionsCounter++;
                    FriendsCounter++;
                }
            }

            if (IntersectionsCounter == 0) return 0;

            CheckedPersons.Add(S);

            do
            {
                int CurrentPerson = PersonsToCheck.Pop();

                for (int i = 0; i < N; i++)
                {
                    if (!CheckedPersons.Contains(i) && friendsGrid[CurrentPerson, i] == 1)
                    {
                        //PersonsToCheck.Push(i);
                        IntersectionsCounter++;
                        FriendsCounter++;
                    }
                }
            } while (PersonsToCheck.Count > 0);

            return FriendsCounter;
        }


        static int[,] GridGenerator(int N)
        {
            int[,] friendsGrid = new int[N, N];

            Random random = new Random();


            //throw random numbers on the grid
            for(int i = 0; i < N; i++)
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

