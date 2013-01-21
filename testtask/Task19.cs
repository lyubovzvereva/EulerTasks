using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    //1 Jan 1900 was a Monday.
    //Thirty days has September,
    //April, June and November.
    //All the rest have thirty-one,
    //Saving February alone,
    //Which has twenty-eight, rain or shine.
    //And on leap years, twenty-nine.
    //A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
    //How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    class Task19
    {
        private int year = 1900;
        private int month = 1;
        private int day = 1;

        private int countFirstMonday = 0;

        public int FindCountOfFirstSundays()
        {
            Day += 6;
            while(Year<2001)
            {
                if(Day==1 && Year>1900)
                {
                    countFirstMonday++;
                }
                Day += 7;
            }
            return countFirstMonday;
        }

        private int Year
        {
            get { return year; }
            set { year = value; }
        }

        private int Month
        {
            get { return month; }
            set
            {
                if(value==13)
                {
                    month = 1;
                    Year++;
                }
                else
                {
                    month = value;
                }
            }
        }

        private int Day
        {
            get { return day; }
            set
            {
                int daysCount = 31;
                switch(Month)
                {
                    case 2:
                        daysCount = IsYearLoop() ? 29 : 28;
                        break;
                    case 9:
                    case 4:
                    case 6:
                    case 11:
                        daysCount = 30;
                        break;
                }
                if(value>daysCount)
                {
                    day = value - daysCount;
                    Month++;
                }
                else
                {
                    day = value;
                }
            }
        }

        private bool IsYearLoop()
        {
            return (Year%4==0 && Year%100!=0) || Year%400==0;
        }
    }
}
