// https://leetcode.com/problems/game-of-life/
//
//  Follow up:
//
//      Could you solve it in-place? Remember that the board needs to be updated at the same time: You cannot update some cells first and then use their updated values to update other cells.
//
//  
//  Submission Details
//  22 / 22 test cases passed.
//      Status: Accepted
//      Runtime: 144 ms
//          
//          Submitted: 0 minutes ago
//

using System;
using System.Threading;

static class Program
{
    public static void Print(this int[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                Console.Write("{0} ", a[i,j] == 1 ? "*" : "o");
            }

            Console.WriteLine();
        }
    }

    public static void GameOfLife(int[,] board) {
        int n = board.GetLength(0);
        int m = board.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int neighbors = 0;
                for (int k = Math.Max(i - 1, 0); k <= Math.Min(n - 1, i + 1); k++)
                {
                    for (int l = Math.Max(j - 1, 0); l <= Math.Min(m - 1, j + 1); l++)
                    {
                        neighbors += board[k, l] & 1;
                    }
                }

                if (neighbors == 3 ||               // This right here is what genious looks like. Credit goes to https://leetcode.com/discuss/user/StefanPochmann
                    neighbors - board[i, j] == 3)   // Take a minute to figure out WHY this works after reading the GOL rules from https://en.wikipedia.org/wiki/Conway's_Game_of_Life
                {
                    board[i, j] |= 2;
                }
            }
        }
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                board[i, j] >>= 1;
            }
        }
    }

    static void Main()
    {
        int n = 15;
        int[,] a = new int[n, n];
        Random rand = new Random();
        for (int i = 0; i < n * n; i++)
        {
            if (rand.Next(n * n) % 3 == 0)
            {
                a[i / n, i % n] = 1;
            }
        }

        for (int i = 0; i < rand.Next(10, 100); i++)
        {
            Console.Clear();
            GameOfLife(a);
            a.Print();
            Thread.Sleep(300);
        }
    }
}
