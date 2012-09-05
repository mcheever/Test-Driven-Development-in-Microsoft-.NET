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
            int[] primes = Primes.GenerateArray(0);
            Assert.AreEqual(0, primes.Length);
        }

        [TestMethod]
        public void ListZero()
        {
            ArrayList primes = Primes.Generate(0);
            Assert.AreEqual(0, primes.Count);
        }

        [TestMethod]
        public void Single()
        {
            int[] primes = Primes.GenerateArray(2);
            Assert.AreEqual(1, primes.Length);
            Assert.AreEqual(2, primes[0]);
        }

        [TestMethod]
        public void ListSingle()
        {
            ArrayList primes = Primes.Generate(2);
            Assert.AreEqual(1, primes.Count);
            Assert.IsTrue(primes.Contains(2));
        }

        [TestMethod]
        public void Prime()
        {
            int[] centArray = Primes.GenerateArray(100);
            Assert.AreEqual(25, centArray.Length);
            Assert.AreEqual(97, centArray[24]);

        }

        [TestMethod]
        public void ListPrime()
        {
            ArrayList centList = Primes.Generate(100);
            Assert.AreEqual(25, centList.Count);
            Assert.AreEqual(97, centList[24]);
        }

        [TestMethod]
        public void Basic()
        {
            int[] primes =
                Primes.GenerateArray(knownPrimes[knownPrimes.Length - 1]);
            Assert.AreEqual(knownPrimes.Length, primes.Length);

            int i = 0;
            foreach (int prime in primes)
                Assert.AreEqual(knownPrimes[i++], prime);
        }

        [TestMethod]
        public void ListBasic()
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
            int[] primes = Primes.GenerateArray(bound);

            foreach (int prime in primes)
                Assert.IsTrue(IsPrime(prime), "is prime");

            foreach (int prime in primes)
            {
                if (IsPrime(prime))
                    Assert.IsTrue(Contains(prime, primes),
                        "contains primes");
                else
                    Assert.IsFalse(Contains(prime, primes),
                        "doesn't contain composites");
            }
        }

        [TestMethod]
        public void ListLots()
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

        private static bool Contains(int value, int[] primes)
        {
            return (Array.IndexOf(primes, value) != -1);
        }
    }
}
