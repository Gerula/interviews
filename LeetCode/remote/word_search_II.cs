//  https://leetcode.com/problems/word-search-ii/
//
//   Given a 2D board and a list of words from the dictionary, find all words in the board.
//
//   Each word must be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once in a word.
//
//   For example,
//   Given words = ["oath","pea","eat","rain"] and board =
//
//   [
//     ['o','a','a','n'],
//     ['e','t','a','e'],
//     ['i','h','k','r'],
//     ['i','f','l','v']
//   ]
//
//   Return ["eat","oath"]. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public class Node 
    {
        private Dictionary<char, Node> Next = new Dictionary<char, Node>();
        public String Word { get; private set; }

        public static Node Build(string[] words)
        {
            return words.Aggregate(
                    new Node(),
                    (acc, x) => {
                        var node = acc;
                        for (var i = 0; i < x.Length; i++)
                        {
                            if (!node.Next.ContainsKey(x[i]))
                            {
                                node.Next[x[i]] = new Node();
                            }
                            
                            node = node.Next[x[i]];
                        }
                        
                        node.Word = x;
                        return acc;
                    });
        }

        public Node GetNext(char c)
        {
            if (Next.ContainsKey(c))
            {
                return Next[c];
            }

            return null;
        }
    }

    //  https://leetcode.com/submissions/detail/52526437/
    //
    //
    //  Submission Details
    //  36 / 36 test cases passed.
    //      Status: Accepted
    //      Runtime: 672 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public IList<string> FindWords(char[,] board, string[] words) {
        var foundWords = new HashSet<String>();
        var trie = Node.Build(words);
        for (var i = 0; i < board.GetLength(0); i++)
        {
            for (var j = 0; j < board.GetLength(1); j++)
            {
                SearchWords(trie, board, i, j, foundWords);
            }
        }

        return foundWords.ToList();
    }

    private void SearchWords(Node node, char[,] board, int line, int column, HashSet<String> words)
    {
        if (line < 0 || line >= board.GetLength(0) ||
            column < 0 || column >= board.GetLength(1))
        {
            return;
        }

        var c = board[line, column];
        var next = node.GetNext(c);
        if (next == null)
        {
            return;
        }

        if (!String.IsNullOrEmpty(next.Word))
        {
            words.Add(next.Word);
        }
        

        board[line, column] = '\0';
        SearchWords(next, board, line + 1, column, words);
        SearchWords(next, board, line - 1, column, words);
        SearchWords(next, board, line, column + 1, words);
        SearchWords(next, board, line, column - 1, words);
        board[line, column] = c;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(",", new Solution().FindWords(new [,] {
                            {'o','a','a','n'},
                            {'e','t','a','e'},
                            {'i','h','k','r'},
                            {'i','f','l','v'}
                        }, new [] { "oath", "pea", "eat", "rain" })));
    }
}
