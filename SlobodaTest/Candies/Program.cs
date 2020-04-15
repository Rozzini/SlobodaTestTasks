using System;
using Candies;

namespace SlobodaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //input X,Y,Z - gifts mass W - total mass for one combination
            int X = Validtaion.Validate('X');
            int Y = Validtaion.Validate('Y');
            int Z = Validtaion.Validate('Z');
            int W = Validtaion.Validate('W');

            //calling method which calculates all possible combinations and printing it as a result
            Console.WriteLine("Result: " + GiftsManagement.TotalGifts(X, Y, Z, W));
        }
    }
}
