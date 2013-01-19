using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task11
    {
        private int[,] array;
        private int maxPr = 0;
        private int adj = 4;
        private int len = 20;
        public Task11()
        {
            var lines = System.IO.File.ReadAllLines("task11.txt");
            array = new int[lines.Count(), lines.Count()];
            for (int i = 0; i < lines.Count(); i++)
            {
                var line = lines[i];
                var splitted = line.Split(' ');
                for (int j = 0; j < splitted.Count(); j++)
                {
                    array[i, j] = Int32.Parse(splitted[j]);
                }
            }
        }
        public int FindMaxProduct()
        {
            for (int i = 0; i < len; i++)
            {
                FindMaxPrInRow(i);
                
                FindMaxPrInColumn(i);
               
            }
            FindMaxPrInLeftToRight();
            FindMaxPrInRightToLeft();
            return maxPr;
        }
        private void FindMaxPrInRightToLeft()
        {
            for (int j = len - 1; j >= adj - 1; j--)
            {
                if (j == len - 1)
                {
                    for (int i = 0; i < len-adj; i++)
                    {
                        ProductRightDiagonal(i, j);
                    }
                }
                else
                {
                    ProductRightDiagonal(0, j);
                }
            }
        }
        private void ProductRightDiagonal(int i, int j)
        {
            List<int> el = new List<int>();
            int i1 = i;
            int j1 = j;
            int count = 0;
            while (i1 < len && j1 > 0)
            {
                if (count < adj)
                {
                    el.Add(array[i1, j1]);
                }
                else
                {
                    if (count == adj)
                    {
                        CalculatePr(el);

                    }
                    el.Remove(array[i1 - adj, j1 + adj]);
                    el.Add(array[i1, j1]);
                    CalculatePr(el);
                }
                count++;
                i1++;
                j1--;
            }
        }
        private void FindMaxPrInLeftToRight()
        {
            for (int j = 0; j <= len - adj; j++)
            {
                if (j == 0)
                {
                    for (int i = 0; i <= len - adj; i++)
                    {
                        ProduceDiagonal(i, j);
                    }
                }
                else
                {
                    ProduceDiagonal(0, j);
                }
            }
        }
        private void ProduceDiagonal(int i, int j)
        {
            List<int> el = new List<int>();
            int i1 = i;
            int j1 = j;
            int count = 0;
            while (i1 < len && j1 < len)
            {
                if (count < adj)
                {
                    el.Add(array[i1, j1]);
                    
                }
                else
                {
                    if (count == adj)
                    {
                        CalculatePr(el);

                    }
                    el.Remove(array[i1 - adj, j1 - adj]);
                    el.Add(array[i1, j1]);
                    CalculatePr(el);
                }
                count++;
                i1++;
                j1++;
            }
        }
        private void FindMaxPrInRow(int iIndex)
        {
            List<int> el = new List<int>();
            for (int j = 0; j < adj; j++)
            {
                el.Add(array[iIndex, j]);
            }
            CalculatePr(el);
            
            for (int j = adj; j < len; j++)
            {
                el.Remove(array[iIndex, j - adj]);
                el.Add(array[iIndex, j]);

                CalculatePr(el);
                
            }
        }
        private void CalculatePr(List<int> list)
        {
            int pr = 1;
            foreach (var l in list)
            {
                pr *= l;
            }
            if (pr > maxPr)
                maxPr = pr;
        }
        private void FindMaxPrInColumn(int jIndex)
        {
            List<int> el = new List<int>();
            for (int i = 0; i < adj; i++)
            {
                el.Add(array[i, jIndex]);
            }
            CalculatePr(el);
            
            for (int i = adj; i < len; i++)
            {
                el.Remove(array[i-adj, jIndex]);
                el.Add(array[i, jIndex]);

                CalculatePr(el);
                
            }
           
        }
        #region bad
        public int FindMaxSum()
        {
            int max = 0;
            for (int i = 0; i < len; i++)
            {
                int sum = FindMaxSumInRow(i);
                if (sum > max)
                    max = sum;
                sum = FindMaxSumInColumn(i);
                if (sum > max)
                    max = sum;
            }

            FindMaxRightDiagonal();
            FindLeftDiagonal();
            if (maxPr < max)
            {
                maxPr = max;
            }

            return maxPr;
        }
        private void FindLeftDiagonal()
        {
            for (int j = len - 1; j > adj - 1; j--)
            {
                if (j == len - 1)
                {
                    for (int i = 0; i <=adj; i++)
                    {
                        int i1 = i;
                        int j1 = j;
                        int sum = 1;
                        int count = 0;
                        while (i1 <len && j1 >= 0)
                        {
                            if (count < adj)
                            {
                                count++;
                                sum *= array[i1, j1];
                            }
                            else
                            {
                                if (array[i1 + adj, j1 - adj] != 0)
                                {
                                    sum = sum / array[i1 + adj, j1 - adj] * array[i1, j1];
                                }
                                else
                                {
                                    sum = 1;
                                    for (int k = 0; k < adj; k++)
                                    {
                                        sum *= array[i1 + k, j1 - k];
                                    }
                                }
                            }
                            if (sum > maxPr)
                                maxPr = sum;
                            i1++;
                            j1--;
                        }
                    }
                }
                else
                {
                    int i1 = len - 1;
                    int j1 = j;
                    int sum = 1;
                    int count = 0;
                    while (i1 < len && j1 >= 0)
                    {
                        if (count < adj)
                        {
                            count++;
                            sum *= array[i1, j1];
                        }
                        else
                        {
                            if (array[i1 + adj, j1 - adj] != 0)
                            {
                                sum = sum / array[i1 + adj, j1 - adj] * array[i1, j1];
                            }
                            else
                            {
                                sum = 1;
                                for (int k = 0; k < adj; k++)
                                {
                                    sum *= array[i1 + k, j1 - k];
                                }
                            }
                        }
                        if (sum > maxPr)
                            maxPr = sum;
                        i1++;
                        j1--;
                    }
                }
            }
        }

        private void FindMaxRightDiagonal()
        {
            for (int j = 0; j <= len - adj; j++)
            {
                if (j == 0)
                {
                    for (int i = 0; i <= len - adj; i++)
                    {
                        int i1 = i;
                        int j1 = j;
                        int sum = 1;
                        int count = 0;
                        while (i1 < len && j1 < len)
                        {
                            if (count < adj)
                            {
                                count++;
                                sum *= array[i1, j1];
                            }
                            else
                            {
                                if (array[i1 - adj, j1 - adj] != 0)
                                {
                                    sum = sum / array[i1 - adj, j1 - adj] * array[i1, j1];
                                }
                                else
                                {
                                    sum = 1;
                                    for (int k = 0; k < adj; k++)
                                    {
                                        sum *= array[i1 - k, j1 - k];
                                    }
                                }

                            }
                            if (sum > maxPr)
                                maxPr = sum;
                            i1++;
                            j1++;
                        }

                    }
                }
                else
                {
                    int i1 = 0;
                    int j1 = j;
                    int sum = 1;
                    int count = 0;
                    while (i1 < len && j1 < len)
                    {
                        if (count < adj)
                        {
                            count++;
                            sum *= array[i1, j1];
                        }
                        else
                        {
                            if (array[i1 - adj, j1 - adj] != 0)
                            {
                                sum = sum / array[i1 - adj, j1 - adj] * array[i1, j1];
                            }
                            else
                            {
                                sum = 1;
                                for (int k = 0; k < adj; k++)
                                {
                                    sum *= array[i1 - k, j1 - k];
                                }
                            }
                        }
                        if (sum > maxPr)
                            maxPr = sum;
                        i1++;
                        j1++;
                    }
                }
            }
        }

        private int FindMaxSumInRow(int iIndex)
        {
            int sum = 1;
            int curMax = 0;
            for (int j = 0; j < adj; j++)
            {
                sum *= array[iIndex, j];
            }
            curMax = sum;
            for (int j = adj; j < len; j++)
            {
                if (array[iIndex, j - adj] != 0)
                {
                    sum = sum / array[iIndex, j - adj] * array[iIndex, j];
                }
                else
                {
                    sum = 1;
                    for (int k = 0; k <adj; k++)
                    {
                        sum *= array[iIndex, j - k];
                    }
                }
                if (sum > curMax)
                    curMax = sum;
            }
            return curMax;
        }
        private int FindMaxSumInColumn(int jIndex)
        {
            int sum = 1;
            int curMax = 0;
            for (int i = 0; i < adj; i++)
            {
                sum *= array[i, jIndex];
            }
            curMax = sum;
            for (int i = adj; i < len; i++)
            {
                if (array[i - adj, jIndex] != 0)
                {
                    sum = sum / array[i - adj, jIndex] * array[i, jIndex];
                }
                else
                {
                    sum = 1;
                    for (int k = 0; k < adj; k++)
                    {
                        sum *= array[i - k, jIndex];
                    }
                }
                if (sum > curMax)
                    curMax = sum;
            }
            return curMax;
        }
    }
        #endregion bad
}
