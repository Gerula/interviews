//  http://www.geeksforgeeks.org/print-ways-break-string-bracket-form/
//  Given a string, find all ways to to break the given string in bracket form. Enclose each substring within a parenthesis.

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution {
    static IEnumerable<String> Break(this String s)
    {
        return String.IsNullOrEmpty(s) ?
                Enumerable.Repeat(String.Empty, 1) :
                Enumerable
                .Range(1, s.Length)
                .Select(x => s.Substring(x).Break().Select(y => String.Format("({0}){1}", s.Substring(0, x), y)))
                .SelectMany(x => x);
    }

    static void Main() 
    {
        foreach (var x in new [] { "abc", "abcd" })
        {
            Console.WriteLine(x);
            Console.WriteLine(String.Join(Environment.NewLine, x.Break()));
        }
    }
}
