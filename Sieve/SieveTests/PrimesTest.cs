using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sieve;
using System.Collections;

namespace SieveTests
{
    [TestClass]
    public class PrimesTest
    {
        private int[] knownPrimes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

        [TestMethod]
        public void Zero()
        {
            ArrayList primes = Primes.Generate(0);
            Assert.AreEqual(0, primes.Count);
        }

        [TestMethod]
        public void ZeroTwo()
        {
            ArrayList primes = Primes.Generate(2);
            Assert.AreEqual(1, primes.Count);
            Assert.IsTrue(primes.Contains(2));
        }

        [TestMethod]
        public void Prime()
        {
            ArrayList centList = Primes.Generate(100);
            Assert.AreEqual(25, centList.Count);
            Assert.AreEqual(97, centList[24]);
        }

        [TestMethod]
        public void Basic()
        {
            ArrayList primes =
                Primes.Generate(knownPrimes[knownPrimes.Length - 1]);
            Assert.AreEqual(knownPrimes.Length, primes.Count);

            int i = 0;
            foreach (int prime in primes)
                Assert.AreEqual(knownPrimes[i++], prime);

            ArrayList centList = Primes.Generate(100);
            Assert.AreEqual(25, centList.Count);
            Assert.AreEqual(97, centList[24]);
        }

        [TestMethod]
        public void Lots()
        {
            int bound = 10101;
            ArrayList primes = Primes.Generate(bound);
            foreach (int prime in primes)
                Assert.IsTrue(IsPrime(prime), "is prime");

            foreach (int prime in primes)
            {
                if (IsPrime(prime))
                    Assert.IsTrue(primes.Contains(prime),
                        "contains primes");
                else
                    Assert.IsFalse(primes.Contains(prime),
                        "doesn't contain composites");
            }
        }

        [TestMethod]
        public void ZeroOne()
        {
            ArrayList primes = Primes.Generate(1);
            Assert.AreEqual(0, primes.Count);
        }

        private static bool IsPrime(int n)
        {
            if (n < 2) return false;

            bool result = true;
            double x = Math.Sqrt(n);
            int i = 2;
            while (result && i <= x)
            {
                result = (0 != n % i);
                i += 1;
            }

            return result;
        }
    }
}
