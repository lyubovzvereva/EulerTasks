using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task13
    {
        List<byte[]> numbers = new List<byte[]>();
        private int len;
        private void ReadNumbers()
        {
            var lines = System.IO.File.ReadAllLines("task13.txt");
            len = lines[0].Length;
            foreach (var line in lines)
            {
                byte[] ar = new byte[len];
                for (int i = 0; i < len; i++)
                {
                    ar[i] = Byte.Parse(line[i].ToString());
                }
                numbers.Add(ar);
            }
        }
    }
}
