using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task12
    {
        private int order;
        long[] primes = new long[500];
        public Task12(int ord)
        {
            order = ord;
            GetPrimeNumbers();
        }

        public long FindNextTriangle()
        {
            int n = 35;
            int first = n;
            int second = n + 1;
            int result = 0;

            var firstPowers = FindPrimesPowers(first);
            do
            {
                var secondPowers = FindPrimesPowers(second);
                result = CalculateNumberOfPowers(firstPowers, secondPowers);
                firstPowers = secondPowers;
                first++;
                second++;
            }
            while (result<order);
            return (first-1)*(second-1)/2;
        }

        private bool lessThanOrderDivisors(long k)
        {
            int count = 0;
            for (int i = 1; i <= k; i++)
            {
                if (k % i == 0)
                {
                    count++;
                }
            }
            return count < order;
        }

        private void GetPrimeNumbers()
        {
            Task10 task = new Task10(order);
            task.Find3();
            primes = task.primes.ToArray();
        }

        private Dictionary<long, int> FindPrimesPowers(int number)
        {
            Dictionary<long, int> primesAndPowers = new Dictionary<long, int>();
            foreach (var p in primes.Where(x => x <= number))
            {
                if (number % p == 0)
                {
                    int power =2;
                    while (number % Math.Pow(p, power) == 0)
                    {
                        power++;
                    }
                    primesAndPowers.Add(p, power-1);
                }
            }
            return primesAndPowers;
        }

        private int CalculateNumberOfPowers(Dictionary<long, int> first, Dictionary<long, int> second)
        {
            int total = 1;
            foreach (var el in second)
            {
                if (first.ContainsKey(el.Key))
                {
                    first[el.Key] += el.Value;
                }
                else
                {
                    first.Add(el.Key, el.Value);
                }
            }
            first[2]--;
            foreach (var el in first)
            {
                total *= el.Value+1;
            }
            return total;
        }
    }
}
