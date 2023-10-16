using System;
using System.Collections;

namespace ConsoleEnum
{
    class Program
    {
        static int[] InitializeIntArrayFromInput(int n)
        {
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            return array;
        }

        private static int CompareIntsByMinValue(int a, int b)
        {
            return a - b;
        }

        static void FindLargestNumberLessOrEqualToK(int[] inputArray, int k)
        {
            Array.Sort(inputArray, CompareIntsByMinValue);

            Console.WriteLine("Sorted array:");

            for (int i = 0; i < inputArray.Length; i++)
            {
                Console.Write(inputArray[i] + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("Largest number <= k in the array is:");

            int indexK = Array.BinarySearch(inputArray, k);

            if (indexK < 0)
            {
                if (~indexK == 0)
                {
                    Console.WriteLine("No number less or equal to K found in array.");
                }
                else
                {
                    Console.WriteLine(inputArray[~indexK - 1]);
                }
            }
            else
            {
                Console.WriteLine(inputArray[indexK]);
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int k = Convert.ToInt32(Console.ReadLine());

            int[] array = InitializeIntArrayFromInput(n);

            FindLargestNumberLessOrEqualToK(array, k);

        }
    }
}

/*
Description
Write a program, that reads from the console an array of N integers and an integer K,
sorts the array and using the method Array.BinSearch() finds the largest number in the
array which is ≤ K.
*/