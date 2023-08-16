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

            // for (int col = n - 1; col >= 0; col--)
            // {
            //     int row = col;

            //     while (row < n)
            //     {
            //         matrix[row, col] = value;
            //         value++;
            //         row++;
            //     }
            // }


            int row = n - 1, col = 0;

            while (row > col)
            {
                while (col < n - 1)
                {
                    matrix[row, col] = value;
                    value++; 
                    col++;
                }
                row--;
            }


            //3,0; | 2,0; 3,1; | 1,0; 2,1; 3,2; | 0,0; 1,1; 2,2; 4,4; | 0,1; 1,2; 2,3; | 0,2; 1,3; | 0,3;

            // for (int row = n - 2; row >= 0; row--)
            // {
            //     int col = n - 1 - row;

            //     while (col < n)
            //     {
            //         matrix[row, col] = value;
            //         value++;
            //         col++;
            //     }
            // }
        }

        static void FillPatternD(int[,] matrix, int n)
        {

        }

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string type = Console.ReadLine()!;

            int[,] matrix = new int[n, n];

            if (type == "a")
            {
                FillPatternA(matrix, n);
            }
            else if (type == "b")
            {
                FillPatternB(matrix, n);
            }
            else if (type == "c")
            {
                FillPatternC(matrix, n);
            }
            else if (type == "d")
            {
                FillPatternD(matrix, n);
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col] + "\t");
                }

                Console.WriteLine();
            }

        }
    }
}

// {
//     {1, 2, 3, 4},
//     {5, 6, 7, 8},
//     {9, 10, 11, 12},
//     {13, 14, 15, 16},
// };


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

*/