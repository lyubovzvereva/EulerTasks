namespace testtask
{
    class Task2SumOfEvenNumberOfFibonachiBelowX
    {
        private long boundary;
        public Task2SumOfEvenNumberOfFibonachiBelowX(long bound)
        {
            boundary = bound;
        }

        public long CalculateSumOfOddBelowBoundary()
        {
            int first = 1;
            int second = 2;
            long sum = second;
            int third = first + second;
            while (third < boundary)
            {
                if (third%2 == 0)
                {
                    sum += third;
                }
                first = second;
                second = third;
                third = first + second;
            }
            return sum;
        }
    }
}
