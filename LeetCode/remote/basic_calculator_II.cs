//  https://leetcode.com/problems/basic-calculator-ii/
//  Implement a basic calculator to evaluate a simple expression string.
//
//  The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.
//
//  You may assume that the given expression is always valid.

using System;
using System.Collections.Generic;
using System.Linq;

class Solution
{
    Dictionary<string, int> priorities = new Dictionary<string, int> {{"+", 1}, {"-", 1}, {"/", 0}, {"*", 0}};

    //  https://leetcode.com/submissions/detail/57124171/
    //
    //  Submission Details
    //  109 / 109 test cases passed.
    //      Status: Accepted
    //      Runtime: 208 ms
    //          
    //          Submitted: 0 minutes ago
    //  You are here!
    //  Your runtime beats 0.00% of csharpsubmissions.
    public int Calculate(string s) 
    {
        var operators = new Stack<string>();
        var operands = new Stack<int>();

        foreach (var token in Tokens(s))
        {
            if (!priorities.ContainsKey(token))
            {
                operands.Push(int.Parse(token));
                continue;
            }

            while (operators.Any() && priorities[token] >= priorities[operators.Peek()])
            {
                Eval(operators, operands); 
            }

            operators.Push(token);
        }

        while (operators.Any())
        {
            Eval(operators, operands); 
        }

        return operands.Pop();
    }

    private void Eval(Stack<String> operators, Stack<int> operands)
    {
        var right = operands.Pop();
        var left = operands.Pop();
        var op = operators.Pop();
        switch (op)
        {
            case "/" : operands.Push(left / right); break;
            case "-" : operands.Push(left - right); break;
            case "*" : operands.Push(left * right); break;
            case "+" : operands.Push(left + right); break;
        }
    }

    private IEnumerable<String> Tokens(string s)
    {
        var token = String.Empty;
        foreach (var c in s)
        {
            if (c == ' ')
            {
                continue;
            }
            
            if (priorities.ContainsKey(c.ToString()))
            {
                yield return token;
                yield return c.ToString();
                token = String.Empty;
            }
            else
            {
                token += c;
            }
        }

        yield return token;
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var x in new [] {
                "3+2*2", 
                " 3/2 ", 
                " 3+5 / 2 "})
        {
            Console.WriteLine("{0} = {1}", x, s.Calculate(x));
        }
    }
}
