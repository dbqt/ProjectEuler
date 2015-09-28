using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectEulerCS
{
    class ProblemSolver
    {
        public long problem3()
        {
            const double ini = 600851475143.0;
            double square = Math.Sqrt(ini);

            long maxFactor = 0;

            // Count down from sqrt(ini) to 2.
            for (long i = Convert.ToInt64(square + 1); i > 1; i--)
            {
                // Check if factor.
                if(ini%i == 0)
                {
                    // We now have te highest factor possible. Highest prime factor will be this one or lower.
                    maxFactor = i;
                    break;
                }
            }

            // Generate prime numbers until value of maxFactor.
            Dictionary<long, bool> potentialPrimes = new Dictionary<long, bool>();
            Stack<long> primes = new Stack<long>();

            for (long i = 2; i < maxFactor; i++)
            {
                potentialPrimes.Add(i, true);
            }

            
            // Flag all non-prime number.
            for (long key = 2; key < potentialPrimes.Count; key++)
            {
                if (!potentialPrimes[key]) { continue; } // Skip if already flagged as non-prime.
                // Otherwise, it's a prime number.
                primes.Push(key);
                // Set all multiples of the next prime number to false.
                for (long i = key + key; i < potentialPrimes.Count; i += key)
                {
                    potentialPrimes[i] = false;
                }
            }

            // Find the first (highest) prime that is also a factor.
            while (ini%primes.Peek() != 0)
            {
                primes.Pop();
            }
            
            return primes.Peek();
        }
    }
}
