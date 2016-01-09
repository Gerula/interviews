//  http://www.geeksforgeeks.org/dynamic-programming-set-28-minimum-insertions-to-form-a-palindrome/
//
//  Given a string, find the minimum number of characters to be inserted to convert it to palindrome.

using System;

static class Program
{
    static int Palind(this String s)
    {
        if (String.IsNullOrEmpty(s))
        {
            return int.MaxValue;
        }

        if (s.Length == 1)
        {
            return 0;
        }

        if (s.Length == 2)
        {
            return s[0] == s[1] ? 0 : 1;
        }

        return s[0] == s[s.Length - 1] ?
               s.Substring(1, s.Length - 2).Palind() :
               (Math.Min(
                    s.Substring(1, s.Length - 1).Palind(),
                    s.Substring(0, s.Length - 1).Palind()) + 1);
    }

    static int PalindDp(this String s)
    {
        var n = s.Length;
        var dp = new int[n, n];
        
        for (var length = 1; length < n; length++)
        {
            for (int i = 0, h = length; h < n; i++, h++)
            {
                dp[i, h] = (s[i] == s[h]) ?
                                dp[i + 1, h - 1] :
                                (Math.Min(dp[i, h - 1], dp[i + 1, h]) + 1);
            }
        }

        return dp[0, n - 1];
    }

    static void Main()
    {
        foreach (var x in new [] {
                    Tuple.Create("ab", 1),
                    Tuple.Create("aa", 0),
                    Tuple.Create("abcd", 3),
                    Tuple.Create("abcda", 2),
                    Tuple.Create("abcde", 4)
                })
        {
            var s = x.Item1;
            var e = x.Item2;
            var a = s.Palind();
            var d = s.PalindDp();
            Console.WriteLine("{0} [{1}, {2}, {3}]", s, e, a, d);
        }
    }
}
