﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testtask
{
    class Task21
    {
        private int border;
        private int sum = 0;
        private Dictionary<int, List<int>> devisors = new Dictionary<int, List<int>>();
        #region primes
        private List<int> primes = new List<int>
                                       {
                                           2,
                                           3,
                                           5,
                                           7,
                                           11,
                                           13,
                                           17,
                                           19,
                                           23,
                                           29,
                                           31,
                                           37,
                                           41,
                                           43,
                                           47,
                                           53,
                                           59,
                                           61,
                                           67,
                                           71,
                                           73,
                                           79,
                                           83,
                                           89,
                                           97,
                                           101,
                                           103,
                                           107,
                                           109,
                                           113,
                                           127,
                                           131,
                                           137,
                                           139,
                                           149,
                                           151,
                                           157,
                                           163,
                                           167,
                                           173,
                                           179,
                                           181,
                                           191,
                                           193,
                                           197,
                                           199,
                                           211,
                                           223,
                                           227,
                                           229,
                                           233,
                                           239,
                                           241,
                                           251,
                                           257,
                                           263,
                                           269,
                                           271,
                                           277
                                       };
//281	283	293	307	311	313	317	331	337	347
//349	353	359	367	373	379	383	389	397	401
//409	419	421	431	433	439	443	449	457	461
//463	467	479	487	491	499	503	509	521	523
//541	547	557	563	569	571	577	587	593	599
//601	607	613	617	619	631	641	643	647	653
//659	661	673	677	683	691	701	709	719	727
//733	739	743	751	757	761	769	773	787	797
//809	811	821	823	827	829	839	853	857	859
//863	877	881	883	887	907	911	919	929	937
        //941	947	953	967	971	977	983	991	997	}
        #endregion
        private bool[] numbers;
        private bool[] proceeded;
        public Task21(int border)
        {
            this.border = border;
            numbers = new bool[border+1];
            proceeded = new bool[border + 1];
        }
        public int FindAmicable()
        {
            FillDevisors();
            devisors.Add(1, new List<int> {1});
            for(int j=2;j<=border;j++)
            {
                if (proceeded[j]) continue;
                int sumLeft = devisors[j].Sum();
                proceeded[j] = true;
                if (sumLeft > border) continue;
                proceeded[sumLeft] = true;
                int sumRight = devisors[sumLeft].Sum();
                if(j==sumRight && j!=sumLeft)
                {
                    sum+=j+sumLeft;
                }
            }
            return sum;
        }

        private void FillDevisors()
        {
            for (int i = 2; i <= border; i++)
            {
                if (numbers[i]) continue;
                FillDevisors(i);
                foreach(int multiple in primes)
                {
                    int temp = i*multiple;
                    if (temp >= border) break;

                    FillFromPrevious(temp, multiple);
                }
            }
        }
        private void FillFromPrevious(int n, int multiple)
        {
            List<int> prevDev = devisors[n/multiple];
            List<int> dev = prevDev.ToList();
            foreach (var d in prevDev.Where(d => !dev.Contains(d * multiple)))
            {
                dev.Add(d*multiple);
            }
            devisors[n] = dev;
            numbers[n] = true;
        }

        private void FillDevisors(int n)
        {
            List<int> dev = new List<int> {1};
            for(int i = 2; i<n;i++)
            {
                if(n%i==0)
                {
                    dev.Add(i);
                }
            }
            devisors[n] = dev;
            numbers[n] = true;
        }

    }
}
