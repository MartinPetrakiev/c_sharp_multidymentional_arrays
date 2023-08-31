using System;

namespace MyProject
{
    class Program
    {
        static void FillPatternA(int[,] matrix, int n)
        {
            int value = 1;

            for (int col = 0; col < n; col++)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = value;
                    value++;
                }
            }
        }

        static void FillPatternB(int[,] matrix, int n)
        {
            int value = 1;

            for (int col = 0; col < n; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = value;
                        value++;
                    }
                }
                else
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix[row, col] = value;
                        value++;
                    }
                }
            }
        }

        static void FillPatternC(int[,] matrix, int n)
        {
            int value = 1;

            //fill below to main diagonal
            for (int row = n - 1; row >= 0; row--)
            {
                for (int col = 0; col < n - row; col++)
                {
                    matrix[row + col, col] = value;
                    value++;
                }
            }

            //fill above main diagonal
            int currentRow = 0;
            int iterations = n - 1;

            for (int i = 1; i <= iterations; i++)
            {
                int currentCol = i;
                while (currentCol <= n - 1 && currentRow < n - i)
                {
                    matrix[currentRow, currentCol] = value;
                    value++;
                    currentRow++;
                    currentCol++;
                }
                currentRow = 0;
            }
        }

        static void FillPatternD(int[,] matrix, int n)
        {
            int value = 1;
            int matrixSize = n * n;
            int colStart = 0, colEnd = n - 1;

            while (value <= matrixSize)
            {
                //fill downwards
                for (int d = colStart; d <= colEnd; d++)
                {
                    matrix[d, colStart] = value;
                    value++;
                }
                //fill right
                for (int r = colStart + 1; r <= colEnd; r++)
                {
                    matrix[colEnd, r] = value;
                    value++;
                }
                //fill up
                for (int u = colEnd - 1; u >= colStart; u--)
                {
                    matrix[u, colEnd] = value;
                    value++;
                }
                //fill left
                for (int l = colEnd - 1; l >= colStart + 1; l--)
                {
                    matrix[colStart, l] = value;
                    value++;
                }
                colStart++;
                colEnd--;
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + "\t");
                }

                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string type = Console.ReadLine()!;

            int[,] matrix = new int[n, n];

            switch (type)
            {
                case "a":
                    FillPatternA(matrix, n);
                    PrintMatrix(matrix);
                    break;
                case "b":
                    FillPatternB(matrix, n);
                    PrintMatrix(matrix);
                    break;
                case "c":
                    FillPatternC(matrix, n);
                    PrintMatrix(matrix);
                    break;
                case "d":
                    FillPatternD(matrix, n);
                    PrintMatrix(matrix);
                    break;
                default:
                    Console.WriteLine("Invalid pattern.");
                    break;
            }
        }
    }
}

/*
Description
Write a program that fills and prints a matrix of size (n, n) as shown below.

Input
On the first line you will receive the number N
On the second line you will receive a character (a, b, c, d*) which determines how to fill the matrix

Output
Print the matrix
Numbers on a row must be separated by a single spacebar
Each row must be on a new line

Constraints
1 <= N <= 128
Time limit: 0.1s
Memory limit: 16MB

Example:

Pattern A
1   5   9   13
2   6   10  14
3   7   11  15
4   8   12  16

Pattern B
1   8   9   16
2   7   10  15
3   6   11  14
4   5   12  13

Pattern C
7   11  14  16
4   8   12  15
2   5   9   13
1   3   6   10

Pattern D
1   12  11  10
2   13  16  9
3   14  15  8
4   5   6   7
*/