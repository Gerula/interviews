// http://careercup.com/question?id=6287528252407808
//
// A k-palindrome is a string which transforms into a palindrome on removing at most k chars.
//
// Given S, return if it is a k-palindrome.
//

using System;
using System.Linq;

static class Program 
{
    static bool KPalindrome(this String s, int k)
    {
        return s.MinEditDistance(s.Invert(), k) <= 2 * k;
    }

    static String Invert(this String s)
    {
        return new String(s.Reverse().ToArray());
    }

    static int MinEditDistance(this String s, String t, int k)
    {
        var dp = new int[s.Length + 1, t.Length + 1];
        for (var i = 0; i <= s.Length; i++)
            for (var j = 0; j <= t.Length; j++)
                dp[i, j] = int.MaxValue;
        for (var i = 0; i < s.Length; i++)
        {
            dp[i, 0] = i;
        }
        for (var j = 0; j < t.Length; j++)
        {
            dp[0, j] = j;
        }

        for (var i = 1; i <= s.Length; i++)
        {
            var from = Math.Max(1, i - k);
            var to = Math.Min(i + k, t.Length);
            for (var j = from; j <= to; j++)
            {
                if (s[i - 1] == t[i - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }

                dp[i, j] = Math.Min(dp[i, j], Math.Min(dp[i - 1, j], dp[i, j - 1]) + 1);
            }
        }

        Console.WriteLine(dp[s.Length, t.Length]);
        return dp[s.Length, t.Length];
    }

    static void Main()
    {
        new [] {
            Tuple.Create("abxa", 1, true),
            Tuple.Create("abdxa", 1, false)
        }
        .ToList()
        .ForEach(x => {
                    var result = x.Item1.KPalindrome(x.Item2);
                    Console.WriteLine("{0} {1}", x.Item1, result);
                    if (result != x.Item3)
                    {
                        throw new Exception("U suck");
                    }
                });
    }
}
