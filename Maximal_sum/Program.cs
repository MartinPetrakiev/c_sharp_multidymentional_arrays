using System;

class Program
{
    static int[,] InitializeInt2DArray(int n, int m)
    {
        int[,] matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] rowValues = Console.ReadLine().Split();
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = Convert.ToInt32(rowValues[j]);
            }
        }

        return matrix;
    }

    static void CalculateMaxSumOf3x3(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        int maxSum = int.MinValue;

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = 0; j < m - 2; j++)
            {
                int currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                                 matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                                 matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                maxSum = Math.Max(maxSum, currentSum);
            }
        }

        Console.WriteLine("max sum: " + maxSum);
    }

    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int n = Convert.ToInt32(dimensions[0]);
        int m = Convert.ToInt32(dimensions[1]);

        int[,] matrix = InitializeInt2DArray(n, m);

        CalculateMaxSumOf3x3(matrix);
    }
}

/*
Description
Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. Print that sum.

Input
On the first line you will receive the numbers N and M separated by a single space
On the next N lines there will be M numbers separated with spaces - the elements of the matrix

Output
Print the maximal sum of 3 x 3 square

Constraints
3 <= N, M <= 1024
Numbers in the matrix will be in the interval [ -1000, 1000 ]
Time limit: 0.1s
Memory limit: 16MB
*/