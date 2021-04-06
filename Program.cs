using System;

namespace rngTryout
{
    class Program
    {
        static void Main()
        {
            byte fullRange = 48;
            byte selectRange = 35;
            var newRound = new Round(selectRange, fullRange);
            byte[] drawnNumbers = newRound.DrawNumbers();

            Console.WriteLine("Drawn numbers in order of selection:");
            foreach (var number in drawnNumbers)
            {
                Console.Write($" {number} ");
            }
            Array.Sort(drawnNumbers);

            Console.WriteLine("\n Drawn numbers ordered by size:");
            foreach (var number in drawnNumbers)
            {
                Console.Write($" {number} ");

            }
        }
    }
}
