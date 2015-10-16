// http://www.geeksforgeeks.org/print-all-jumping-numbers-smaller-than-or-equal-to-a-given-value/
//
// A number is called as a Jumping Number if all adjacent digits in it differ by 1. The difference between ‘9’ and ‘0’ is not considered as 1.
// All single digit numbers are considered as Jumping Numbers. For example 7, 8987 and 4343456 are Jumping numbers but 796 and 89098 are not.
//
// Given a positive number x, print all Jumping Numbers smaller than or equal to x. The numbers can be printed in any order.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static List<int> Jump(this int n)
    {
        return Enumerable.
                    Range(1, 9).
                    ToList().
                    SelectMany(x => Dfs(x, n)).
                    ToList();
    }

    static IEnumerable<int> Dfs(int current, int max)
    {
        if (current > max)
        {
            return Enumerable.Empty<int>();
        }

        var digit = current % 10;
        var result = new List<int>();
        result.Add(current);

        if (digit + 1 <= 9)
        {
            result.AddRange(Dfs(current * 10 + digit + 1, max));
        }

        if (digit - 1 >= 0)
        {
            result.AddRange(Dfs(current * 10 + digit - 1, max));
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(
                    Environment.NewLine, 
                    new [] { 20, 105, 5000 }.
                        Select(x => String.Join(
                                            ", ",
                                            x.Jump()))));
    }
}
