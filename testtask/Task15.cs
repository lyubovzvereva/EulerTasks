using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task15
    {
        private int n;
        private long[,] matrix;
        public Task15(int n)
        {
            this.n = n;
            matrix = new long[n,n];
        }
        public long FindVariants2()
        {
            matrix[n - 1, n - 1] = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    long right = 0;
                    long bottom = 0;
                    if (i + 1 < n)
                    {
                        right = matrix[i + 1, j];
                    }
                    if (j + 1 < n)
                    {
                        bottom = matrix[i, j + 1];
                    }
                    if (i == n - 1 && j == n - 1)
                        continue;
                    matrix[i, j] = right + bottom; 
                }
            }
            return matrix[0, 0];
        }
        public long FindVariants()
        {
            matrix[n - 1, n - 1] = 1;
            int i = n - 1;
            int j = n - 1;
            while (i >= 0 && j >= 0)
            {
                int i1 = i;
                int j1 = j;
                while (i1 >= 0)
                {
                    long right = 0;
                    long bottom = 0;
                    if (i1 + 1 < n)
                    {
                        right = matrix[i1 + 1, j1];
                    }
                    if (j + 1 < n)
                    {
                        bottom = matrix[i1, j1 + 1];
                    }
                    if (i1 == n - 1 && j == n - 1)
                    {
                        i1--;
                        continue;
                    }
                    matrix[i1, j] = right + bottom;
                    i1--;
                }
                while (j1 >= 0)
                {
                    long right = 0;
                    long bottom = 0;
                    if (i + 1 < n)
                    {
                        right = matrix[i + 1, j1];
                    }
                    if (j1 + 1 < n)
                    {
                        bottom = matrix[i, j1 + 1];
                    }
                    if (i == n - 1 && j1 == n - 1)
                    {
                        j1--;
                        continue;
                    }
                    matrix[i, j1] = right + bottom;
                    j1--;
                }
                i--;
                j--;
            }

            return matrix[0, 0];
        }
    }
}
