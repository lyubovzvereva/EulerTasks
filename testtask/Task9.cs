using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task9
    {
        public int[] Find()
        {
            int[] result = new int[3];
            int b = 759;
            int c = 0;
            while (true)
            {
                var x = (Math.Pow(b, 2) - 100 * b + 500000);
                var y = (1000 - b);
                if (x % y == 0)
                {
                    c = (int)(x / y);
                    if (1000-b-c>0 && c>0) 
                        break;
                }
                b++;
            }
            result[0] = b;
            result[2] = c;
            result[1] = 1000 - b - c;
            return result;
        }

        public int[] Find2()
        {
            for (int a = 1; a < 1000; a++)
            {
                for (int b = a; b < 1000; b++)
                {
                    for (int c = b; c < 1000; c++)
                    {
                        if ((a + b + c == 1000) && (a * a + b * b == c * c))
                            return new int[] { a, b, c };
                    }
                }
            }
            return new int[3];
        }
    }
}
