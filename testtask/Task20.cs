using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task20
    {
        int number;
        
        public Task20(int number)
        {
            this.number = number;
        }

        public int FindSumOfFactorial()
        {
            List<byte> mult = new List<byte>(){1};
            for (int i = 2; i <= number; i++)
            {
                mult = Multiple(mult, FindArray(i));
            }
            return mult.Sum(x=>x);
        }
        private List<byte> FindArray(int n)
        {
            List<byte> result = new List<byte>();
            while (n > 0)
            {
                result.Add((byte)(n % 10));
                n = (int)Math.Floor((decimal)(n / 10));
            }
            return result;
        }

        private List<byte> Multiple(List<byte> first, List<byte> second)
        {
            List<List<byte>> subSums = new List<List<byte>>();
            for (int i = 0; i < second.Count; i++)
            {
                List<byte> subResult = new List<byte>();
                int tempI = i;
                while (tempI > 0)
                {
                    subResult.Add(0);
                    tempI--;
                }
                int tempSum = 0;
                for (int j = 0; j < first.Count; j++)
                {
                    int mult = second[i] * first[j] + tempSum;
                    subResult.Add((byte)(mult % 10));
                    tempSum = (int)Math.Floor((decimal)(mult / 10));
                }
                while (tempSum > 0)
                {
                    subResult.Add((byte)(tempSum % 10));
                    tempSum = (int)Math.Floor((decimal)(tempSum / 10));
                }
                subSums.Add(subResult);
            }
            return Sum(subSums);
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
