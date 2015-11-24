// http://careercup.com/question?id=5177378863054848
//
// Write a function to retrieve the total number of string palindromes.
//
// For example ABBA -> 6
// A, B, B, A, BB, ABBA
//

using System;
using System.Collections.Generic;

static class Program
{
    static List<String> Palindromes(this String s)
    {
        var result = new List<String>();
        var n = s.Length;
        var palind = new bool[n, n];
        for (var i = 0; i < n; i++)
        {
            palind[i, i] = true;
            result.Add(s.Substring(i, 1));
        }

        for (var i = n - 2; i >= 0; i--)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (j - i == 1)
                {
                    palind[i, j] = s[i] == s[j];
                }
                else
                {
                    palind[i, j] = s[i] == s[j] && palind[i + 1, j - 1];
                }

                if (palind[i, j])
                {
                    result.Add(s.Substring(i, j - i + 1));
                }
            }
        }

        return result;
    }

    static String Join(this List<String> s, String delim)
    {
        return String.Join(delim, s);
    }

    static void Main()
    {
        Console.WriteLine("ABBA".Palindromes().Join(Environment.NewLine));        
        Console.WriteLine("AAB".Palindromes().Join(Environment.NewLine));        
        Console.WriteLine("ABABBBABBABABA".Palindromes().Join(Environment.NewLine));
        // Impressive VIM feature: ~ will toggle the casing of the selection or of the current char
        // Neat!
    }
}
