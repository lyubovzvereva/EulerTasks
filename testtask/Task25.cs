using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task25
    {
        private int numberOfDigits;
        public Task25(int numberOfDigits)
        {
            this.numberOfDigits = numberOfDigits;
        }

        public int FindFibonachiNumber()
        {
            int count = 3;
            List<byte> first = new List<byte> { 1 };
            List<byte> second = new List<byte> { 1 };
            List<byte> third = Sum(new List<List<byte>> { first, second });
            //while (third.Count != numberOfDigits)
            do
            {
                first = second;
                second = third;
                third = Sum(new List<List<byte>> { first, second });
                count++;
            }
            while (third.Count != numberOfDigits);
            return count;
        }

        private List<byte> Sum(List<List<byte>> subSums)
        {
            List<byte> result = new List<byte>();
            int len = subSums[subSums.Count - 1].Count;
            int temp = 0;
            for (int i = 0; i < len; i++)
            {
                int sum = temp;
                foreach (var list in subSums)
                {
                    if (list.Count > i)
                    {
                        sum += list[i];
                    }
                }
                result.Add((byte)(sum % 10));
                temp = (int)Math.Floor((decimal)(sum / 10));
            }
            while (temp > 0)
            {
                result.Add((byte)(temp % 10));
                temp = (int)Math.Floor((decimal)(temp / 10));
            }
            return result;
        }
    }
}
