//  Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
//
//  For example, given n = 3, a solution set is:
//
//  "((()))", "(()())", "(())()", "()(())", "()()()" 
//

using System;
using System.IO;
using System.Collections.Generic;

class Program {
    
    private static void GenerateParenthesis(int total, int left, int right, List<Char> result)
    {
        if ((left == total) && (right == total))
        {
            Console.WriteLine(String.Join("", result));
        }

        if (left < total)
        {
            result.Add('(');
            GenerateParenthesis(total, left + 1, right, result);
            result.RemoveAt(result.Count - 1);
        }

        if (right < left)
        {
            result.Add(')');
            GenerateParenthesis(total, left, right + 1, result);
            result.RemoveAt(result.Count - 1);
        }
    }

    public static void Main(String[] args) {
        GenerateParenthesis(3, 0, 0, new List<Char>());
    }
}
