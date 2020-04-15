using System;
using Sloboda_friends;

namespace Sloboda_friends
{
    class Program
    {
        public static void Main()
        {
            bool Pass = false;

            int N = InputValidator.Validate('N');
            do
            {
                if (N > 0) Pass = true;
                else { Pass = false; N = InputValidator.Validate('N'); }

            } while (Pass == false); 

            int S = InputValidator.Validate('S');
            do
            {
                if (S < N) Pass = true;
                else { Pass = false; S = InputValidator.Validate('S'); }
            }while (Pass == false); ;

            int[,] FriendsGrid = Grid.GridGenerator(N);

            Grid.DrawGrid(FriendsGrid, N);

            Console.WriteLine("\nResult: " + SlobodaFriends.FindFriends(S, FriendsGrid, N));

        }

    }

}

