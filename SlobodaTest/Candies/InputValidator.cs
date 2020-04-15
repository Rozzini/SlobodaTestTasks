using System;
using System.Collections.Generic;
using System.Text;

namespace Candies
{
    public class Validtaion
    {

        //User input validation
        public static int Validate(char Symbol)
        {
            bool Validation = true;
            string input;
            int Grams = 0;
            while (!Validation == false)
            {
                //cheking if input symbol is integer
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
    }
}
