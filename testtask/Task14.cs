using System.Collections.Generic;

namespace testtask
{
    class Task14
    {
        private int border;
        private bool[] numbersProceeded;
        private Dictionary<long, long> sequnces = new Dictionary<long, long>();
        private long maxCount = 0;
        private int maxNumber = 0;
        public Task14(int border)
        {
            this.border = border;
            numbersProceeded = new bool[border + 1];
        }

        public long FindMaxSequence()
        {
            for(int i=1;i<=border;i++)
            {
                if(numbersProceeded[i])
                {
                    continue;
                }
                long current = i;
                long count = 0;
                while(current!=1)
                {
                    current = GetNextElement(current);
                    count++;
                    if(sequnces.ContainsKey(current))
                    {
                        count += sequnces[current];
                        break;
                    }
                    if(current<=border)
                        numbersProceeded[current] = true;
                }
                sequnces.Add(i, count);
                if(count>maxCount)
                {
                    maxNumber = i;
                    maxCount = count;
                }
            }
            return maxNumber;
        }
      

        private long GetNextElement(long n)
        {
            if(n%2==0)
            {
                return n/2;
            }
            return 3*n + 1;
        }
    }
}
