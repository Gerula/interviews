//  https://leetcode.com/problems/word-search/
//
//   Given a 2D board and a word, find if the word exists in the grid.
//
//   The word can be constructed from letters of sequentially adjacent cell,
//   where "adjacent" cells are those horizontally or vertically neighboring.
//   The same letter cell may not be used more than once. 
//
//
//   Submission Details
//   83 / 83 test cases passed.
//      Status: Accepted
//      Runtime: 172 ms
//          
//          Submitted: 0 minutes ago
//

using System;

public class Solution {
    public bool Exist(char[,] board, string word) {
        for (var i = 0; i < board.GetLength(0); i++)
        {
            for (var j = 0; j < board.GetLength(1); j++)
            {
                if (Exists(board, i, j, 0, word))
                {
                    return true;
                }
            }
        }
        return false;
    }

    static bool Exists(char[,] board, int line, int column, int position, String word)
    {
        if (position == word.Length)
        {
            return true;
        }

        if (line < 0 || line == board.GetLength(0) ||
            column < 0 || column == board.GetLength(1) ||
            word[position] != board[line, column])
        {
            return false;
        }
        
        var c = board[line, column];
        board[line, column] = (char)0;
        var result = Exists(board, line - 1, column, position + 1, word) ||
                     Exists(board, line + 1, column, position + 1, word) ||
                     Exists(board, line, column - 1, position + 1, word) ||
                     Exists(board, line, column + 1, position + 1, word);
        board[line, column] = c;
        return result;
    }

    //  https://leetcode.com/submissions/detail/66520579/
    //
    //  Submission Details
    //  87 / 87 test cases passed.
    //      Status: Accepted
    //      Runtime: 172 ms
    //          
    //          Submitted: 1 minute ago
    public bool Exist(char[,] board, string word) {
        for (var i = 0; i < board.GetLength(0); i++) {
            for (var j = 0; j < board.GetLength(1); j++) {
                if (Search(board, i, j, word, 0)) {
                    return true;
                }
            }
        }
        
        return false;
    }
    
    private bool Search(char[,] board, int i, int j, string word, int index) {
        if (index == word.Length || 
            0 > i || i >= board.GetLength(0) ||
            0 > j || j >= board.GetLength(1) ||
            board[i, j] != word[index]) {
                return false;
            }
        
            if (index == word.Length - 1) {
                return true;
            }
            
            var c = board[i, j];
            board[i, j] = char.MinValue;
            var result = Search(board, i + 1, j, word, index + 1) ||
                         Search(board, i, j + 1, word, index + 1) ||
                         Search(board, i - 1, j, word, index + 1) ||
                         Search(board, i, j - 1, word, index + 1);
            board[i, j] = c;
            return result;
    }

    static void Main()
    {
        var s = new Solution();
        var a = new [,] {
            {'A','B','C','E'},
            {'S','F','C','S'},
            {'A','D','E','E'}
        };

        Console.WriteLine(s.Exist(a, "ABCCED"));
        Console.WriteLine(s.Exist(a, "SEE"));
        Console.WriteLine(s.Exist(a, "ABCB"));
    }
}
