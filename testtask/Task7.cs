using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    public class Task7
    {
        private int orderNumber;
        public Task7(int number)
        {
            orderNumber = number;
        }

        public int FindPrimeNumber()
        {
            int count = 1;
            int current = 3;
            while (count < orderNumber)
            {
                //List<int> facrors = new List<int>();
                //FindPrimeFactor(current, facrors);
                //if (facrors.Count == 1)
                //{
                //    count++;
                //}
                if (IsPrime(current))
                    count++;
                current += 2;
            }
            return current - 2;
        }

        public int FindPrime()
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int current = 3;
            while (primes.Count < orderNumber)
            {
                bool isPrime = true;
                foreach (var p in primes)
                {
                    if (current % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(current);
                }
                current += 2;
            }
            return current - 2;
        }

        /// <summary>
        /// Recursion method
        /// </summary>
        /// <param name="n"></param>
        /// <param name="factors"> </param>
        private void FindPrimeFactor(long n, List<int> factors)
        {
            if (n == 1)
                return;
            for (int i = 2; i <= n; i++)
            {
                if (n % i != 0) continue;
                factors.Add(i);
                FindPrimeFactor(n / i, factors);
                break;
            }
        }

        private bool IsPrime(long n)
        {
            long current = n;
            for (int i = 3; i < n; i+=2)
            {
                if (n % i == 0)
                    return false;
            }
            
            return true;
        }
    }
}
