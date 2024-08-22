using System;

namespace patika_csharp_kurs
{
    class FibonacciOrtalamaVeUcgen
    {

        public void PrintFibonacciTriangle(int height)
        {
            int totalElements = height * (height + 1) / 2;
            int[] fibonacciNumbers = GenerateFibonacciSeries(totalElements);

            int index = 0;
            for (int i = 1; i <= height; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write(fibonacciNumbers[index++] + " ");
                }
                Console.WriteLine();
            }

            double average = CalculateAverage(fibonacciNumbers);
            Console.WriteLine($"Fibonacci dizi ortalaması: {average}");
        }

        static int[] GenerateFibonacciSeries(int count)
        {
            int[] fibonacciSeries = new int[count];
            if (count > 0) fibonacciSeries[0] = 1;
            if (count > 1) fibonacciSeries[1] = 1;

            for (int i = 2; i < count; i++)
            {
                fibonacciSeries[i] = fibonacciSeries[i - 1] + fibonacciSeries[i - 2];
            }

            return fibonacciSeries;
        }

        static double CalculateAverage(int[] numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return (double)sum / numbers.Length;
        }
    }
}
