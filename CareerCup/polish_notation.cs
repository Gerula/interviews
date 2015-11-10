// Write a program to parse and compute a prefix expression
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Program
{
    static int Compute(this String e)
    {
        var stack = new Stack<int>();
        var acc = new StringBuilder(); 
        foreach (var c in e.Reverse())
        {
            if (Char.IsDigit(c))
            {
                acc.Append(c);
                continue;
            }

            if ((c == ' ' || c.IsOperator()) && acc.Length > 0)
            {
                stack.Push(int.Parse(new String(acc.ToString().Reverse().ToArray())));
                acc.Length = 0;
            }

            if (c.IsOperator())
            {
                var left = stack.Pop();
                var right = stack.Pop();
                stack.Push(c.Compute(left, right));
            }
        }

        return stack.Pop();
    }

    static bool IsOperator(this char c)
    {
        switch (c)
        {
            case '+':
            case '-':
            case '*':
            case '/': return true;
            default: return false;
        }
    }

    static int Compute(this char c, int left, int right)
    {
        switch (c)
        {
            case '+': return left + right;
            case '-': return left - right;
            case '*': return left * right;
            case '/': return left / right;
        }

        return int.MinValue;
    }

    static void Main()
    {
        Console.WriteLine(
                String.Join(
                    Environment.NewLine,
                    new [] {
                        "* -6 5  7",
                        "- 5* 6 7",
                        "- * / 15 - 7 + 1 1 3 + 2 + 1 1",
                        "*3 +4 5",}.
                    Select(x => String.Format("{0} = {1}", x, x.Compute()))));
    }
}
