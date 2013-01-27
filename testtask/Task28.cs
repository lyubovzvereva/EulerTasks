using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task28
    {
        private int[,] array;
        private int range;
        public Task28(int range)
        {
            this.range = range;
            array = new int[range, range];
            FillArray();
        }

        private void FillArray()
        {
            int i = range / 2 + 1;
            int j = range / 2 + 1;
            int current = 1;
            int addI = 1;
            int addJ = 1;
            while (array[i, j] == 0)
            {
                array[i, j] = current;
                current++;
                if (addI>0 && i + addI < range)
                {
                    i+=addI;
                }
                else if (addI > 0)
                {
                    addI = -1;
                }
                if (addI < 0 && i + addI >= 0)
                {
                    i += addI;
                }
                else if (addI < 0)
                {
                    addI = 1;
                }

                if (addJ > 0 && j + addJ < range)
                {
                    j += addJ;
                }
                else if (addJ > 0)
                {
                    addJ = -1;
                }
                if (addJ < 0 && j + addJ >= 0)
                {
                    j += addJ;
                }
                else if (addJ < 0)
                {
                    addJ = 1;
                }
            }
        }
    }
}
