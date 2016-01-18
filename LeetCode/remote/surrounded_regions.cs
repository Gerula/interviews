//  https://leetcode.com/problems/surrounded-regions/
//
//   Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.
//
//   A region is captured by flipping all 'O's into 'X's in that surrounded region.
//
//   For example,
//
//   X X X X
//   X O O X
//   X X O X
//   X O X X
//
//   After running your function, the board should be:
//
//   X X X X
//   X X X X
//   X X X X
//   X O X X
//

using System;
using System.Collections.Generic;
using System.Threading;

public class Solution {
    public void Solve(char[,] board) {
        var n = board.GetLength(0);
        var m = board.GetLength(1);
        var borderReplacements = new Dictionary<char, char> { {'O', 'Y'} };
        int stackSize = 1024*1024*64;
        for (var i = 0; i < n; i++)
        {
            var thread = new Thread(() => 
            {
                Fill(board, i, m - 1, borderReplacements);
            }, stackSize);
            thread.Start();
            thread.Join();
        }

        for (var i = 0; i < m; i++)
        {
            var thread = new Thread(() => 
            {
                Fill(board, n - 1, i, borderReplacements);
            }, stackSize);
            thread.Start();
            thread.Join();
        }

        var finalReplacements = new Dictionary<char, char> { {'O', 'X'} };
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                var thread = new Thread(() => 
                {
                    Fill(board, i, j, finalReplacements);
                }, stackSize);
                thread.Start();
                thread.Join();
            }
        }

        borderReplacements = new Dictionary<char, char> { {'Y', 'O'} };
        for (var i = 0; i < n; i++)
        {
            var thread = new Thread(() => 
            {
                Fill(board, i, m - 1, borderReplacements);
            }, stackSize);
            thread.Start();
            thread.Join();
        }

        for (var i = 0; i < m; i++)
        {
            var thread = new Thread(() => 
            {
                Fill(board, n - 1, i, borderReplacements);
            }, stackSize);
            thread.Start();
            thread.Join();
        }
    }

    public void Fill(char[,] board, int line, int col, Dictionary<char, char> replacements)
    {
        if (!replacements.ContainsKey(board[line, col]))
        {
            return;
        }

        board[line, col] = replacements[board[line, col]];;
        for (var a = Math.Max(0, line - 1); a <= Math.Min(board.GetLength(0) - 1, line + 1); a++)
        {
            for (var b = Math.Max(0, col - 1); b <= Math.Min(board.GetLength(1) - 1, col + 1); b++)
            {
                if (a != b)
                {
                    Fill(board, a, b, replacements);
                }
            }
        }
    }

    public void Print(char[,] board)
    {
        for (var i = 0; i < board.GetLength(0); i++)
        {
            for (var j = 0; j < board.GetLength(1); j++)
            {
                Console.Write("{0} ", board[i, j]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void Main()
    {
        var s = new Solution();
        var a = new char[4, 4] { 
            { 'X', 'X', 'X', 'X' },
            { 'X', 'O', 'O', 'X' },
            { 'X', 'X', 'O', 'X' },
            { 'X', 'O', 'X', 'X' },
        };

        s.Print(a);
        s.Solve(a);
        s.Print(a);
    }
}
