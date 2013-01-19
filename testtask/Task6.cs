namespace testtask
{
    class Task6
    {
        private int number;
        public Task6(int number)
        {
            this.number = number;
        }
        public int Calculate()
        {
            int sum = 0;
            for (int i =2; i<=number; i++)
            {
                sum += i*(i - 1)*i;
            }
            return sum;
        }
    }
}
