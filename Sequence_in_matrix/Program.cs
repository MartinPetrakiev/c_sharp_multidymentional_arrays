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

    static void FindMaxSeqenceOfEqualElements(int[,] matrix, int n, int m)
    {
        int maxSequence = 1;
        int sequenceToCurrent = 1;

        //check by row
        for (int row = 0; row < n; row++)
        {
            sequenceToCurrent = 1;

            for (int col = 1; col < m; col++)
            {
                if (matrix[row, col] == matrix[row, col - 1])
                {
                    sequenceToCurrent++;
                    maxSequence = Math.Max(maxSequence, sequenceToCurrent);
                }
                else
                {
                    sequenceToCurrent = 1;
                }
            }
        }

        //check by col
        for (int col = 0; col < m; col++)
        {
            sequenceToCurrent = 1;

            for (int row = 1; row < n; row++)
            {
                if (matrix[row, col] == matrix[row - 1, col])
                {
                    sequenceToCurrent++;
                    maxSequence = Math.Max(maxSequence, sequenceToCurrent);
                }
                else
                {
                    sequenceToCurrent = 1;
                }
            }
        }

        //check diagonals by row
        for (int row = 0; row < n; row++)
        {
            maxSequnece = 1;
            sequenceToCurrent = 1;

            for (int col = 1; col < n; col++)
            {
                if (row + col < n && matrix[row + col, col] == matrix[row + col - 1, col - 1])
                {
                    sequenceToCurrent++;
                    maxSequnece = Math.Max(maxSequnece, sequenceToCurrent);
                }
                else
                {
                    sequenceToCurrent = 1;
                }
            }
        }

        //check diagonals by column
        for (int col = 1; col < n; col++)
        {
            maxSequnece = 1;
            sequenceToCurrent = 1;

            for (int row = 1; row < n; row++)
            {
                if (col + row < n && matrix[row, col + row] == matrix[row - 1, col + row - 1])
                {
                    sequenceToCurrent++;
                    maxSequnece = Math.Max(maxSequnece, sequenceToCurrent);
                }
                else
                {
                    sequenceToCurrent = 1;
                }
            }
        }

        Console.WriteLine(maxSequence);
    }

    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int n = Convert.ToInt32(dimensions[0]);
        int m = Convert.ToInt32(dimensions[1]);

        int[,] matrix = InitializeInt2DArray(n, m);

        FindMaxSeqenceOfEqualElements(matrix, n, m);

    }
}

/*
Description
We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix and prints its length.

Input
On the first line you will receive the numbers N and M separated by a single space
On the next N lines there will be M strings separated with spaces - the strings in the matrix

Output
Print the length of the longest sequence of equal equal strings in the matrix

Constraints
3 <= N, M <= 128
Time limit: 0.1s
Memory limit: 16MB
*/