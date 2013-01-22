using System;
using System.Collections.Generic;

namespace testtask
{

    class Program
    {
        static void Main(string[] args)
        {
            Task20Test();
        }
        #region tasks test

        private static void Task20Test()
        {
            Task20 task = new Task20(100);
            Console.WriteLine(task.FindSumOfFactorial());
            //var result = task.Multiple(new List<byte> { 4, 5, 6, 7, 1, 5, 5, 6, 7, 1 }, new List<byte> { 8, 9, 7, 4, 3, 3, 5, 6, 7, 1 });
            Console.ReadLine();
        }


        private static void Task19Test()
        {
            Task19 task = new Task19();
            Console.WriteLine(task.FindCountOfFirstSundays());
            Console.ReadLine();
        }

        private static void Task17Test()
        {
            Task17 task = new Task17();
            Console.WriteLine(task.CalculateCharacters());
            Console.ReadLine();
        }


        private static void Task12Test()
        {
            Task12 task = new Task12(500);
            Console.WriteLine(task.FindNextTriangle());
            Console.ReadLine();
        }


        private static void Task11Test()
        {
            Task11 task = new Task11();
            Console.WriteLine(task.FindMaxProduct());
            Console.ReadLine();
        }

        private static void Task10Test()
        {
            Task10 task = new Task10(2000000);
            Console.WriteLine(task.Find3());
            Console.ReadLine();
        }


        private static void Task9Test()
        {
            Task9 task = new Task9();
            var result = task.Find2();
            Console.WriteLine("{0}*{1}*{2}={3}", result[0], result[1], result[2], result[0]*result[1]*result[2]);
            Console.ReadLine();
        }

        private static void Task7Test()
        {
            Task7 task = new Task7(10001);
            Console.WriteLine(task.FindPrime());
            Console.ReadLine();
        }

        private static void Task8Test()
        {
            string input = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";
            string input2 = "1230456720564";
            Task8 task = new Task8(input, 5);
            Console.WriteLine(task.FindMaxProduct());
            Console.ReadLine();
        }

        private static void Task6Test()
        {
            Task6 task = new Task6(100);
            Console.WriteLine(task.Calculate());
            Console.ReadLine();
        }
        private static void Task5Test()
        {
            Task5 task = new Task5(20);
            Console.WriteLine(task.MinProduct());

            Console.ReadLine();
        }
        private static void Task1Test()
        {
            Task1SumOfMultiplesOf3And5Below1000 task = new Task1SumOfMultiplesOf3And5Below1000(3, 5, 1000);
            Console.WriteLine(task.SumAllMultiplesFromTwo());

            Console.WriteLine(task.SumAllMultiplesUsingComparisons());
            Console.ReadLine();
        }

        private static void Task2Test()
        {
            Task2SumOfEvenNumberOfFibonachiBelowX task = new Task2SumOfEvenNumberOfFibonachiBelowX(4000000);
            Console.WriteLine(task.CalculateSumOfOddBelowBoundary());

            Console.ReadLine();
        }

        private static void Task3Test()
        {
            Task3PrimeFactors task = new Task3PrimeFactors(600851475143);
            Console.WriteLine(task.FindLargestPrimeFactor());

            Console.ReadLine();
        }

        private static void Task4Test()
        {
            Task4ProductsPalindrom task = new Task4ProductsPalindrom();
            var result = task.FindProducts();
            Console.WriteLine("{0}*{1}={2}", result[0], result[1], result[2]);

            Console.ReadLine();
        }
        #endregion
    }
}
