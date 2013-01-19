using System;

namespace testtask
{
    /// <summary>
    /// Sum of multiples x and y below z
    /// </summary>
    class Task1SumOfMultiplesOf3And5Below1000
    {
        private int firstNumber;
        private int secondNumber;
        private int border;
        public Task1SumOfMultiplesOf3And5Below1000(int first, int second, int border)
        {
            firstNumber = first;
            secondNumber = second;
            this.border = border;
        }

        public long SumAllMultiplesFromTwo()
        {
            return SumAllMultiples(firstNumber) + SumAllMultiples(secondNumber) -
                   SumAllMultiples(firstNumber*secondNumber);
        }

        public long SumAllMultiplesUsingComparisons()
        {
            long total = 0;
            long sum = 0;
            for(int i = 0; i<border; i++)
            {
                total++;
                if(i%firstNumber == 0)
                {
                    sum += i;
                    total++;
                }
                else if(i%secondNumber ==0)
                {
                    sum += i;
                    total += 2;
                }
                else
                {
                    total += 2;
                }
            }
            Console.WriteLine("total = {0}", total);
            return sum;
        }

        private long SumAllMultiples(int number)
        {
            long total = 0;
            int current = number;
            long sum = 0;
            while (current < border)
            {
                total++;
                sum += current;
                current += number;
            }
            Console.WriteLine("total for number {0}={1}", number, total);
            return sum;
        }
    }
}
