using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task10
    {
        private int orderNumber;
        public List<long> primes = new List<long>();
        public Task10(int order)
        {
            orderNumber = order;
        }
        public long FindSumPrime()
        {
            List<int> primes = new List<int>();
            long sum = 2;
            primes.Add(2);
            int current = 3;
            while (current < orderNumber)
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
                    sum += current;
                }
                current += 2;
            }
            return sum;
        }

       public long Find3()
        {
            bool[] Sieve = new bool[orderNumber+1];
            long sum = 0;

            Sieve[0] = true;
            Sieve[1] = true;

            // Check all nos from 2 to 1 million
            for (long i = 2; i < orderNumber; ++i)
            {
                if (Sieve[i])  // If marked not prime
                    continue;    // return to head of loop
                else
                    // Set all multiples as not prime
                    for (long j = i * i; j <orderNumber; j += i)
                        Sieve[j] = true;
            }
            for (long i = 2; i < orderNumber; i++)
            {
                if (!Sieve[i])
                {
                    sum += i;
                    primes.Add(i);
                }
            }
            return sum;
        }


    }
}
