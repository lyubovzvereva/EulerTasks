using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task5
    {
        private int border;
        private List<int> numbers = new List<int>();
        public Task5(int border)
        {
            this.border = border;
        }
        private void FindFactors()
        {
            for(int i = border; i>1; i--)
            {
                if (numbers.Any(x => x % i == 0)) continue;
                List<int> factors = new List<int>();
                FindPrimeFactor(i, factors);
                var temp = numbers.ToList();
                foreach (var factor in factors)
                {
                    if(temp.Any(x=>x==factor))
                    {
                        temp.Remove(factor);
                    }
                    else
                    {
                        numbers.Add(factor);
                    }
                    //numbers.Add(factor);
                }
            }
        }

        public long MinProduct()
        {
            FindFactors();
            return numbers.Aggregate<int, long>(1, (current, n) => current*n);
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
    }
}
