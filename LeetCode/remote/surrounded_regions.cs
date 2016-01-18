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

public class Solution {
    public void Solve(char[,] board) {
        var n = board.GetLength(0);
        var m = board.GetLength(1);
        var borderReplacements = new Dictionary<char, char> { {'O', 'Y'} };
        for (var i = 0; i < n; i++)
        {
            Fill(board, i, m - 1, borderReplacements);
            Fill(board, i, 0, borderReplacements);
        }

        for (var i = 0; i < m; i++)
        {
            Fill(board, n - 1, i, borderReplacements);
            Fill(board, 0, i, borderReplacements);
        }

        var finalReplacements = new Dictionary<char, char> { {'O', 'X'} };
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                Fill(board, i, j, finalReplacements);
            }
        }

        borderReplacements = new Dictionary<char, char> { {'Y', 'O'} };
        for (var i = 0; i < n; i++)
        {
            Fill(board, i, m - 1, borderReplacements);
            Fill(board, i, 0, borderReplacements);
        }

        for (var i = 0; i < m; i++)
        {
            Fill(board, n - 1, i, borderReplacements);
            Fill(board, 0, i, borderReplacements);
        }
    }

    public void Fill(char[,] board, int line, int col, Dictionary<char, char> replacements)
    {
        var stack = new Stack<Tuple<int, int>>();
        stack.Push(Tuple.Create(line, col));

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            line = current.Item1;
            col = current.Item2; 
            if (!replacements.ContainsKey(board[line, col]))
            {
                continue;
            }

            board[line, col] = replacements[board[line, col]];
            for (var a = Math.Max(0, line - 1); a <= Math.Min(board.GetLength(0) - 1, line + 1); a++)
            {
                for (var b = Math.Max(0, col - 1); b <= Math.Min(board.GetLength(1) - 1, col + 1); b++)
                {
                    if (a != b)
                    {
                        stack.Push(Tuple.Create(a, b));
                    }
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
        
        a = new char[2, 2] { 
            { 'O', 'O' },
            { 'O', 'O' }
        };

        s.Print(a);
        s.Solve(a);
        s.Print(a);
    }
}
