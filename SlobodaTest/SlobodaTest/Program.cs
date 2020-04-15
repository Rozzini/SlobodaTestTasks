using System;
using System.Collections.Generic;
using System.Linq;

namespace SlobodaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int X = Validation('X');
            int Y = Validation('Y');
            int Z = Validation('Z');
            int W = Validation('W');
            Console.WriteLine("Result: " + TotalGifts(X, Y, Z, W));
        }


        //User input validation
        public static int Validation(char Symbol)
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


        //returns amount of combinaisions that have given sum
        public static int TotalGifts(int X, int Y, int Z, int W)
        {
            int TargetNumber = W;
            List<int> numbers = new List<int>{X,Y,Z};
            numbers.Sort();
            List<int> temporaryList = new List<int>();
            List<List<int>> resultList = new List<List<int>>();
            GiftsQuantity(numbers, TargetNumber, resultList, temporaryList, 0);


            return resultList.Count();
        }


        //Calculates total all combinations that have given sum. 
        public static void GiftsQuantity(List<int> numbers, int targetNumber, List<List<int>> resultList, List<int> temporaryList, int iterator)
        {
            if (targetNumber < 0)
                return;

            // if we get exact answer 
            if (targetNumber == 0)
            {
                resultList.Add(temporaryList);
                return;
            }

            // Recur for all remaining elements that have value smaller than sum. 
            while (iterator < numbers.Count() && targetNumber - numbers[iterator] >= 0)
            {

                // Till every element in the array starting 
                // from i which can contribute to the sum 
                temporaryList.Add(numbers[iterator]); // add them to list 

                // recur for next numbers 
                GiftsQuantity(numbers, targetNumber - numbers[iterator], resultList, temporaryList, iterator);
                iterator++;

                // remove last number from list 
                temporaryList.Remove(temporaryList.Count-1);
                
            }
        }
    }
}
