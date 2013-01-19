namespace testtask
{
    class Task4ProductsPalindrom
    {
        private bool IsPalindrome(long number)
        {
            string n = number.ToString();
            int len = n.Length;
            for(int i =0; i<len/2;i++)
            {
                if (n[i] != n[len - i - 1])
                    return false;
            }
            return true;
        }

        private long product = 1;
        public long[] FindProducts()
        {
            long[] result = new long[3];
            for(int i = 999; i>99;i--)
            {
                for (int j = 990; j > 99; j-=11)
                {
                    if(IsPalindrome(i*j) && i*j> product)
                    {
                        result[0] = i;
                        result[1] = j;
                        product = i * j;
                        result[2] = product;
                    }
                }
            }
            return result;
        }
    }
}
