namespace testtask
{
    class Task3PrimeFactors
    {
        private long number;
        public Task3PrimeFactors(long number)
        {
            this.number = number;
        }

        private int maxPrimeFactor = 1;

        public int FindLargestPrimeFactorRecursion()
        {
            FindPrimeFactor(number);
            return maxPrimeFactor;
        }
        /// <summary>
        /// Recursion method
        /// </summary>
        /// <param name="n"></param>
        private void FindPrimeFactor(long n)
        {
            if (n == 1)
                return;
            for(int i = 2; i<=n; i++)
            {
                if (n%i != 0) continue;
                if(i>maxPrimeFactor)
                {
                    maxPrimeFactor = i;
                }
                FindPrimeFactor(n/i);
                break;
            }
        }

        public int FindLargestPrimeFactor()
        {
            long current = number;
            while(current>1)
            {
                long temp = current;
                for(int i=2; i<=temp; i++)
                {
                    if(current%i ==0)
                    {
                        current = current / i;
                        if (i > maxPrimeFactor)
                        {
                            maxPrimeFactor = i;
                        }
                        break;
                    }
                }
            }
            return maxPrimeFactor;
        }
    }
}
