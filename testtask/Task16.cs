using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task16
    {
        private int power;

        private List<byte> numbers = new List<byte>();

        public Task16(int power, byte number)
        {
            this.power = power;
            this.numbers.Add(number);
        }
        public double FindSum()
        {
            int currentPower = 1;
            while(currentPower<power)
            {
                numbers = sumNumbers(numbers);
                currentPower++;
            }
            //foreach(var n in numbers)
            //{
            //    Console.WriteLine(n);
            //}
            return numbers.Sum(x=>x);
        }

        private List<byte> sumNumbers(List<byte> number)
        {
            List<byte> sum = new List<byte>();
            decimal prev = 0;
            for(int i=0;i<number.Count;i++)
            {
                decimal res = number[i]*2+prev;
                sum.Add((byte)(res%10));
                prev = Math.Floor(res/10);
            }
            while(prev>0)
            {
                sum.Add((byte) (prev%10));
                prev = Math.Floor(prev / 10);
            }
            return sum;
        }
    }
}
