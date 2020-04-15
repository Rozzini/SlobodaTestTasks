using System;
using System.Collections.Generic;
using System.Text;

namespace Sloboda_friends
{
    class InputValidator
    {
        public static int Validate(char Symbol)
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

                //added this to avoid stack overflow
                if (Value < 0)
                {
                    Console.WriteLine("please input valid number");
                    Validation = true;
                }
            }
            return Value;
        }
    }
}
