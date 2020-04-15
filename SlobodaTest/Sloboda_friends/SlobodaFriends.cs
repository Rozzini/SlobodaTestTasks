using System;
using System.Collections.Generic;
using System.Text;

namespace Sloboda_friends
{
    class SlobodaFriends
    {
        public static int FindFriends(int S, int[,] friendsGrid, int N)
        {
            int FriendsCounter = 0;
            int IntersectionsCounter = 0;
            Stack<int> PersonsToCheck = new Stack<int>();
            List<int> CheckedPersons = new List<int>();


            //Checking friends for given person first, and if he have friends adding them to stack and also increment total quiantity of friends 
            for (int i = 0; i < N; i++)
            {
                if (friendsGrid[S, i] == 1)
                {
                    PersonsToCheck.Push(i);
                    IntersectionsCounter++;
                    FriendsCounter++;
                }
            }

            //if person have 0 friends return 0
            if (IntersectionsCounter == 0) return 0;

            //adding given person to list of checked persons
            CheckedPersons.Add(S);

            do
            {
                //taking not checked person from stack
                int CurrentPerson = PersonsToCheck.Pop();


                //cheking friends for taken person
                for (int i = 0; i < N; i++)
                {
                    //if friend wasnt added to list of checked persons and also if this person is really friends with CurrentPerson increment total friends count
                    if (!CheckedPersons.Contains(i) && friendsGrid[CurrentPerson, i] == 1)
                    {

                        if (!CheckedPersons.Contains(i)) PersonsToCheck.Push(i);
                        //CheckedPersons.Add(i);
                        IntersectionsCounter++;
                        FriendsCounter++;
                    }
                }
                CheckedPersons.Add(CurrentPerson);
            } while (PersonsToCheck.Count > 0);

            return FriendsCounter;
        }
    }
}
