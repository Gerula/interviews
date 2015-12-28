//  https://leetcode.com/problems/basic-calculator/
//
//  Implement a basic calculator to evaluate a simple expression string.
//
//  The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .
//
//  You may assume that the given expression is always valid.

using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public int Calculate(string s) {
        var operands = new Stack<int>();
        var operators = new Stack<String>();
        foreach (var token in GetTokens(s))
        {
            switch (token)
            {
                case "(" : 
                case "+" : 
                case "-" : operators.Push(token); break;
                case ")" : Evaluate(operators, operands); break;
                default : operands.Push(int.Parse(token)); 
                          Evaluate(operators, operands);
                          break;
            }
        }

        while (operators.Count != 0)
        {
            Evaluate(operators, operands);
        }

        return operands.Pop();
    }

    public void Evaluate(Stack<String> operators, Stack<int> operands)
    {
        while (operators.Count != 0)
        {
            var op = operators.Pop();
            if (op == "(")
            {
                return;
            }

            var right = operands.Pop();
            var left = operands.Pop();
            if (op == "+")
            {
                operands.Push(left + right);
            }
            else
            {
                operands.Push(left - right);
            }
        }
    }

    public IEnumerable<String> GetTokens(string s)
    {
        var acc = new StringBuilder();
        foreach (var c in s)
        {
            if (c == '-' || c == '+' || c == '(' || c == ')')
            {
                if (acc.Length != 0)
                {
                    yield return acc.ToString();
                    acc.Length = 0;
                }

                yield return c.ToString();
            }

            if ('0' <= c && c <= '9')
            {
                acc.Append(c);
            }
        }

        if (acc.Length != 0)
        {
            yield return acc.ToString();
        }
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.Calculate("1 + 1"));
        Console.WriteLine(s.Calculate(" 2-1 + 2 "));
        Console.WriteLine(s.Calculate("(1+(4+5+2)-3)+(6+8)"));
        Console.WriteLine(s.Calculate("(1+(4+5+2)-3)+(6+89)"));
    }
}
