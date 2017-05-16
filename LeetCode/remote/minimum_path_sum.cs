// https://leetcode.com/problems/minimum-path-sum/
//
// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
//
// Note: You can only move either down or right at any point in time.
//
// 61 / 61 test cases passed.
//  Status: Accepted
//  Runtime: 164 ms
//      
//      Submitted: 0 minutes ago
//
//      https://leetcode.com/submissions/detail/43211435/
//
//      You are here!
//      Your runtime beats 98.00% of csharp submissions. <- It's not actually THAT fast. It's basically a boilerplate solution but nobody's working at this hour.

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

    //  https://leetcode.com/submissions/detail/64906703/
    //
    //  Submission Details
    //  61 / 61 test cases passed.
    //      Status: Accepted
    //      Runtime: 192 ms
    //          
    //          Submitted: 0 minutes ago
    public int MinPathSum(int[,] grid) {
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                if (i == 0 && j == 0) 
                {
                    continue;
                }
                
                if (i == 0)
                {
                    grid[i, j] += grid[i, j - 1];
                    continue;
                }
                
                if (j == 0)
                {
                    grid[i, j] += grid[i - 1, j];
                    continue;
                }
                
                grid[i, j] += Math.Min(grid[i - 1, j], grid[i, j - 1]);
            }
        }
        
        return grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1];
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

//  https://leetcode.com/problems/minimum-path-sum/
//
//  Submission Details
//  61 / 61 test cases passed.
//      Status: Accepted
//      Runtime: 180 ms
//          
//          Submitted: 0 minutes ago
//  It's evolution, baby!
public class Solution {
    public int MinPathSum(int[,] grid) {
        for (var i = grid.GetLength(0) - 1; i >= 0; i--)
        {
            for (var j = grid.GetLength(1) - 1; j >= 0; j--)
            {
                if (i == grid.GetLength(0) - 1 && j == grid.GetLength(1) - 1)
                {
                    continue;
                }
                
                grid[i, j] += Math.Min(i == grid.GetLength(0) - 1 ? int.MaxValue : grid[i + 1, j],
                                       j == grid.GetLength(1) - 1 ? int.MaxValue : grid[i, j + 1]);
            }
        }
        return grid[0, 0];
    }
}
