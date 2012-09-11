using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieve
{
    public class Primes
    {
        public static ArrayList Generate(int maxValue)
        {
            Primes primes = new Primes(maxValue);
            return primes.Sieve();
        }

        private bool[] isPrime;

        private Primes(int maxValue)
        {
            isPrime = new bool[maxValue + 1];
            for (int i = 0; i < isPrime.Length; i++)
                isPrime[i] = true;
        }

        private ArrayList Sieve()
        {
            if (isPrime.Length < 2)
                return new ArrayList();

            ArrayList result = new ArrayList();

            for (int i = 2; i < isPrime.Length; i++)
            {
                if (isPrime[i])
                {
                    result.Add(i);
                    RemoveMultiples(i, isPrime);
                }
            }
            return result;
        }

        private void RemoveMultiples(int prime, bool[] isPrime)
        {
            for (int j = 2 * prime; j < isPrime.Length; j += prime)
                isPrime[j] = false;
        }
    }
}
