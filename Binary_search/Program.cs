using System;

class Program
{
    static int[] InitializeIntArray(int n)
    {
        int[] array = new int[n];

        for (int i = 0; i < n; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        return array;
    }

    static void FindLargestNumberLessOrEqualToK(int[] array, int k)
    {
        Array.Sort(array);

        Console.WriteLine("Sorted array:");

        for (int i = 0;i< array.Length; i++)
        {
            Console.Write(array[i] + "\t");
        }

        Console.WriteLine();
        Console.WriteLine("Largest number <= k in the array is:");

        int indexK = Array.BinarySearch(array, k);

        if(indexK < 0)
        {
            Console.WriteLine(array[~indexK - 1]);
        }
        else
        {
            Console.WriteLine(array[indexK]);
        }
    }

    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int k = Convert.ToInt32(Console.ReadLine());

        int[] array = InitializeIntArray(n);

        FindLargestNumberLessOrEqualToK(array, k);

    }
}

/*
Description
Write a program, that reads from the console an array of N integers and an integer K,
sorts the array and using the method Array.BinSearch() finds the largest number in the
array which is ≤ K.
*/