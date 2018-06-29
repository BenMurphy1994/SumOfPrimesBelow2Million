using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimesBelow2Million
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int rangeStart = 1;
            int rangeEnd = 2000000;

            //Create hashset from 1 - 2000000 (million).
            HashSet<int> numbers = new HashSet<int>(Enumerable.Range(rangeStart, rangeEnd));
            HashSet<int> primeNumbers = new HashSet<int>();

            foreach(int number in numbers)
            {
                if(IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            }

            Console.WriteLine($"Worked out primes. Number of prime numbers below {rangeEnd}: {primeNumbers.Count()}\n");

            //Use Int64 instead of int as int.MAX_VALUE is too low. 
            Int64 sumOfPrimes = 0;

            foreach (int primeNumber in primeNumbers)
            {
                sumOfPrimes += primeNumber;
            }

            stopWatch.Stop();

            string timeTaken = stopWatch.Elapsed.ToString("ss\\.ff");

            Console.WriteLine($"Sum of all primes below 2 million: {sumOfPrimes}\n");
            Console.WriteLine($"Time taken: {timeTaken} seconds");
            Console.ReadLine();
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
