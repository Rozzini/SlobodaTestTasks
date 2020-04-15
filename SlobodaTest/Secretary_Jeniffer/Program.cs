using System;
using Secretary_Jeniffer;

namespace Secretary_Jeniffer
{
    class Program
    {
        static void Main(string[] args)
        {
            //input N - needed amount of copies, x,y - Time that periner needed to print 1 copy
            int N = InputValidator.Validate('N');
            int x = InputValidator.Validate('x');
            int y = InputValidator.Validate('y');

            //Calling time calculation method and printing it as a result
            Console.WriteLine("Result : " + PrintingTime.PrintingTimeCalculation(N, x, y));
        }
    }
}
