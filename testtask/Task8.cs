using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task8
    {
        private int[] array;
        private int seq;
        public Task8(string input, int sequence)
        {
            seq = sequence;
            FillArray(input);
        }
        private void FillArray(string input)
        {
            array = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i] = Int32.Parse(input[i].ToString());
            }
        }

        public int FindMaxProduct()
        {
            int current = 1;
            int max;
            for (int i = 0; i < seq; i++)
            {
                current *= array[i];
            }
            max = current;
            for (int i = seq; i < array.Length; i++)
            {
                if (array[i - seq] != 0)
                {
                    current = current * array[i] / array[i - seq];
                }
                else
                {
                    current = 1;
                    for (int j = i-seq+1; j < i+1; j++)
                    {
                        current *= array[j];
                    }
                }
                if (current > max)
                    max = current;
            }
            return max;
        }
    }
}
