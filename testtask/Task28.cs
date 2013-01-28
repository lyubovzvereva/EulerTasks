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

        public long SumOfTheDiagonals()
        {
            long sum = -1;
            for(int i = 0; i<range; i++)
            {
                sum += array[i, i];
                sum += array[i, range - i - 1];
            }
            return sum;
        }

        private void FillArray()
        {
            int i = range / 2;
            int j = range / 2;
            int current = 1;
            array[i, j] = current;
            j++;
            current++;
            array[i, j] = current;
            current++;
            while(current<=range*range)
            {
                int iTemp = i;
                int jTemp = j;
                NextPossibleIndexes(ref iTemp, ref jTemp);
                if(array[iTemp, jTemp] == 0)
                {
                    array[iTemp, jTemp] = current;
                    currentDirection = GetNextDirection();
                    i = iTemp;
                    j = jTemp;
                }
                else
                {
                    NextIndexesInCurrentDirection(ref i, ref j);
                    array[i, j] = current;
                }
                current++;
            }

        }
        internal enum Directions
        {
            Right,
            Down,
            Left, 
            Top
        }

        private Directions currentDirection = Directions.Right;

        private Directions GetNextDirection()
        {
            Directions result = Directions.Right;
            switch (currentDirection)
            {
                case Directions.Right:
                    result = Directions.Down;
                    break;
                case Directions.Down:
                    result = Directions.Left;
                    break;
                case Directions.Left:
                    result = Directions.Top;
                    break;
            }
            return result;
        }

        private void NextPossibleIndexes(ref int i, ref int j)
        {
            var nextDirection = GetNextDirection();
            switch(nextDirection)
            {
                case Directions.Right:
                    j++;
                    break;
                case Directions.Down:
                    i++;
                    break;
                case Directions.Left:
                    j--;
                    break;
                case Directions.Top:
                    i--;
                    break;
            }
        }
        private void NextIndexesInCurrentDirection(ref int i, ref int j)
        {
            switch (currentDirection)
            {
                case Directions.Right:
                    j++;
                    break;
                case Directions.Down:
                    i++;
                    break;
                case Directions.Left:
                    j--;
                    break;
                case Directions.Top:
                    i--;
                    break;
            }
        }

    }
}
