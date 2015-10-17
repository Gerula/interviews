// https://leetcode.com/problems/minimum-path-sum/
//
// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
//
// Note: You can only move either down or right at any point in time.
//

using System;

static class Program 
{
    static void Print(this int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write("{0} ", grid[i, j]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static int MinPathSum(int[,] grid) 
    {
        grid.Print();
        int n = grid.GetLength(0);
        int m = grid.GetLength(1);
        for (int i = n - 2; i >= 0; i--)
        {
            grid[i, m - 1] += grid[i + 1, m - 1]; 
        }

        for (int i = m - 2; i >= 0; i--)
        {
            grid[n - 1, i] += grid[n - 1, i + 1];
        }

        for (int i = n - 2; i >= 0; i--)
        {
            for (int j = m - 2; j >=0; j--)
            {
                grid[i, j] += Math.Min(grid[i + 1, j], grid[i, j + 1]);
            }
        }

        grid.Print();
        return grid[0, 0];
    }

    static void Main()
    {
        Console.
            WriteLine(
                MinPathSum(new [,] { 
                    { 1, 2, 3, 4, 5 },
                    { 1, 4, 1, 0, 3 },
                    { 2, 1, 3, 9, 0 },
                    { 2, 7, 3, 9, 6 },
                    { 1, 1, 2, 4, 6 },
                    { 5, 4, 3, 2, 1 }
                    }));
    }
}
