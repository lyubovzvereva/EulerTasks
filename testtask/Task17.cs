using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task17
    {
        Dictionary<int, int> numbers = new Dictionary<int, int>();
        public Task17()
        {
            FillDictionary();
        }
        private void FillDictionary()
        {
            numbers.Add(1, 3);
            numbers.Add(2, 3);
            numbers.Add(3, 5);
            numbers.Add(4, 4);
            numbers.Add(5, 4);
            numbers.Add(6, 3);
            numbers.Add(7, 5);
            numbers.Add(8, 5);
            numbers.Add(9, 4);

            numbers.Add(10, 3);
            numbers.Add(20, 5);
            numbers.Add(30, 6);
            numbers.Add(40, 6);
            numbers.Add(50, 5);
            numbers.Add(60, 5);
            numbers.Add(70, 7);
            numbers.Add(80, 6);
            numbers.Add(90, 6);

            numbers.Add(1000, 11);

            numbers.Add(11, 6);
            numbers.Add(12, 6);
            numbers.Add(13, 8);
            numbers.Add(14, 8);
            numbers.Add(15, 7);
            numbers.Add(16, 7);
            numbers.Add(17, 9);
            numbers.Add(18, 8);
            numbers.Add(19, 8);
        }

        public int CalculateCharacters()
        {
            //десятки
            for (int i = 2; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    int number = i * 10 + j;
                    if (numbers.ContainsKey(number))
                    {
                        continue;
                    }
                    int count = numbers[i * 10] + numbers[j];
                    numbers.Add(number, count);
                }
            }
            //сотни
            for (int i = 1; i <= 9; i++)
            {
                int number = i * 100;
                int count = numbers[i] + 7;
                numbers.Add(number, count);
                for (int j = 1; j <= 99; j++)
                {
                    int num = i * 100 + j;
                    int count1 = numbers[i * 100] + 3 + numbers[j];
                    numbers.Add(num, count1);
                }
            }
            //21124
            return numbers.Values.Sum();
        }
    }
}
