using System;

namespace Secretary_Jeniffer
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Validation('N');
            int x = Validation('x');
            int y = Validation('y');
            Console.WriteLine("Result : " + PrintingTime(N, x, y));
        }


        //took validation from Candies)
        public static int Validation(char Symbol)
        {
            bool Validation = true;
            string input;
            int Value = 0;
            while (!Validation == false)
            {
                Console.Write(Symbol + "= ");
                input = Console.ReadLine();
                if (int.TryParse(input, out Value))
                {
                    Validation = false;
                }
                if (Value <= 0)
                {
                    Console.WriteLine("please input valid number");
                    Validation = true;
                }
            }
            return Value;
        }


        //Returns time needed to print required amount of copies
        public static int PrintingTime(int N, int x, int y)
        
        {
            int MaxTime;

            int TimeForFirstCopy;

            //determining the least time to print first copy and setting maximum possible time using slowest printer
            if (x < y)
            {
                TimeForFirstCopy = x;
                MaxTime = y * N;
            }
            else
            {
                TimeForFirstCopy = y;
                MaxTime = x * N;
            }


            //Adding time requireded to print first copy to counter
            int TotalTimeTaken = TimeForFirstCopy;
            int CurrentCopies = 1;


            //cheking if it is requireded 1 copie, and returning total time if true
            if(N == 1)
            {
                return TotalTimeTaken;
            }


            //cycle which checking if reminder of division between total time,
            //and time that printer takes to print 1 copie is equal 0, and if true add copies to Current copies counter (for both of printers) 
            for (int i = 0; i <= MaxTime; i++)
            {
                if(TotalTimeTaken >= x)
                {
                    if(TotalTimeTaken % x ==0)
                    {
                        CurrentCopies++;
                    }
                }

                if (TotalTimeTaken >= y)
                {
                    if (TotalTimeTaken % y == 0)
                    {
                        CurrentCopies++;
                    }
                }
                TotalTimeTaken++;
                if (CurrentCopies >= N) break;
            }
            return TotalTimeTaken;
        }
    }
}
