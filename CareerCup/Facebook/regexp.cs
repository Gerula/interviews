// http://careercup.com/question?id=6631993756352512
//
// Given a regular expression with characters a-z, * and .
// find if it matches a given string.
//

using System;
using System.Collections.Generic;

static class Program
{
    static bool Match(this String regex, String other)
    {
        var dp = new bool[regex.Length + 1, other.Length + 1];
        dp[0, 0] = true;

        for (var i = 1; i <= regex.Length; i++)
        {
            var c = regex[i - 1];
            for (var j = 0; j <= other.Length; j++)
            {
                if (c != '*')
                {
                    dp[i, j] = j > 0 && dp[i - 1, j - 1] && (c == '.' || c == other[j - 1]);
                }
                else
                {
                    dp[i, j] = (i > 1 && dp[i - 2, j]) ||
                               (j > 0 && dp[i, j - 1] && (regex[i - 2] == '.' || regex[i - 2] == other[j - 1]));
                }
            }
        }

        return dp[regex.Length, other.Length];
    }

    static void Main()
    {
        foreach (var input in new[] {
                    Tuple.Create("a*", "", true),
                    Tuple.Create("ab*", "a", true),
                    Tuple.Create(".", "", false),
                    Tuple.Create("a.", "ab", true),
                    Tuple.Create("a", "a", true),
                    Tuple.Create("a*bc", "bc", true)
                })
        {
            var result = input.Item1.Match(input.Item2);
            Console.WriteLine("{0} - {1}", input, result);
            if (input.Item3 != result)
            {
                throw new Exception("You suck");
            }
        }
    }
}
