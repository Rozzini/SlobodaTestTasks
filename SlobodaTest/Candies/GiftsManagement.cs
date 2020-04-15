using System;
using System.Collections.Generic;
using System.Linq;

namespace Candies
{
    class GiftsManagement
    {
        //returns amount of combinaisions that have given sum
        public static int TotalGifts(int X, int Y, int Z, int W)
        {
            int TargetNumber = W;
            List<int> numbers = new List<int> { X, Y, Z };
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

            // if get exact answer 
            if (targetNumber == 0)
            {
                resultList.Add(temporaryList);
                return;
            }

            // While with recurcive call for all remaining elements that have value smaller than sum 
            while (iterator < numbers.Count() && targetNumber - numbers[iterator] >= 0)
            {
                temporaryList.Add(numbers[iterator]); // adding number with current iteratir to list 

                // recursive call for next numbers 
                GiftsQuantity(numbers, targetNumber - numbers[iterator], resultList, temporaryList, iterator);
                iterator++;

                // remove last number from list 
                temporaryList.Remove(temporaryList.Count - 1);

            }
        }
    }
}
