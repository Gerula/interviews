//  https://leetcode.com/problems/generate-parentheses/
//
//   Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
//
//   For example, given n = 3, a solution set is:
//
//   "((()))", "(()())", "(())()", "()(())", "()()()"
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Solution {
    //  
    //  Submission Details
    //  8 / 8 test cases passed.
    //      Status: Accepted
    //      Runtime: 396 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/50831763/
    public IList<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        GenPar(n, n, result, new StringBuilder());
        return result;
    }

    public void GenPar(int open, int closed, IList<string> result, StringBuilder partial)
    {
        if (open == 0 && closed == 0)
        {
            result.Add(partial.ToString());
            return;
        }

        if (open > 0)
        {
            partial.Append("(");
            GenPar(open - 1, closed, result, partial);
            partial.Length--;
        }

        if (closed > open)
        {
            partial.Append(")");
            GenPar(open, closed - 1, result, partial);
            partial.Length--;
        }
    }

    public IList<string> GenerateParenthesis2(int n) {
        var result = new List<string>();
        GenPar(n, n, result, new StringBuilder());
        return result;
    }

    static void Main()
    {
        var s = new Solution();
        for (var i = 0; i < 5; i++)
        {
            Console.WriteLine(i);
            Console.WriteLine(String.Join(Environment.NewLine, s.GenerateParenthesis(i)));
            Console.WriteLine();
            Console.WriteLine(String.Join(Environment.NewLine, s.GenerateParenthesis2(i)));
            Console.WriteLine();
        }
    }
}
