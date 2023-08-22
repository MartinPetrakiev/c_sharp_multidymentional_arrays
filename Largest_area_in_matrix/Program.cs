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

        int[] dx = { -1, 1, 0, 0 }; // Offsets for adjacent cells (up, down, left, right)
        int[] dy = { 0, 0, -1, 1 };

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (!visited[row, col])
                {
                    int currentElement = matrix[row, col];
                    int currentArea = 0;

                    Queue<(int, int)> queue = new Queue<(int, int)>();
                    queue.Enqueue((row, col));

                    while (queue.Count > 0)
                    {
                        var (x, y) = queue.Dequeue();

                        bool checkX = x < 0 || x >= matrix.GetLength(0);
                        bool checkY = y < 0 || y >= matrix.GetLength(1);

                        if (checkX || checkY || visited[x, y] || matrix[x, y] != currentElement)
                        {
                            continue;
                        }

                        visited[x, y] = true;
                        currentArea++;

                        for (int i = 0; i < 4; i++)
                        {
                            int newX = x + dx[i];
                            int newY = y + dy[i];
                            queue.Enqueue((newX, newY));
                        }
                    }

                    maxArea = Math.Max(maxArea, currentArea);
                }
            }
        }

        Console.WriteLine(maxArea);
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