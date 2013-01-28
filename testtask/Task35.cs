using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task35
    {
        private int border;
        private List<long> primes;
        //10
        public Task35(int below)
        {
            border = below;
            Task10 findPrimes = new Task10(below);
            findPrimes.Find3();
            primes =  findPrimes.primes;
        }
    }
}
