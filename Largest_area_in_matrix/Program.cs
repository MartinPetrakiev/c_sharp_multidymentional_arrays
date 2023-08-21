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

    static void FindLargestEqualArea(int[,] matrix)
    {
        int maxArea = 0;
        bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (!visited[row, col])
                {
                    int currentElement = matrix[row, col];
                    int currentArea = DepthFirstSearch(matrix, visited, row, col, currentElement);
                    maxArea = Math.Max(maxArea, currentArea);
                }
            }
        }

        Console.WriteLine(maxArea);
    }

    static int DepthFirstSearch(int[,] matrix, bool[,] visited, int row, int col, int target)
    {
        if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || visited[row, col] || matrix[row, col] != target)
        {
            return 0;
        }

        visited[row, col] = true;
        int area = 1;

        area += DepthFirstSearch(matrix, visited, row - 1, col, target);
        area += DepthFirstSearch(matrix, visited, row + 1, col, target);
        area += DepthFirstSearch(matrix, visited, row, col - 1, target);
        area += DepthFirstSearch(matrix, visited, row, col + 1, target);

        return area;
    }

    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int n = Convert.ToInt32(dimensions[0]);
        int m = Convert.ToInt32(dimensions[1]);

        int[,] matrix = InitializeInt2DArray(n, m);

        FindLargestEqualArea(matrix);

    }
}

/*
Description
Write a program that finds the largest area of equal neighbour elements in a rectangular
matrix and prints its size.

Input
● On the first line you will receive the numbers N and M separated by a single
space
● On the next N lines there will be M numbers separated with spaces - the
elements of the matrix

Output
Print the size of the largest area of equal neighbour elements

Constraints
● 3 <= N, M <= 1024
● Time limit: 0.35s
● Memory limit: 24MB
*/