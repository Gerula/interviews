//  http://www.careercup.com/question?id=5705610449387520
//
//  Find the length of a maximum palindrome subset in an array.
//  For example: in 1, 2, 4, 1 the maximum palindrome subset is 1, 2, 1 and the answer is 3

using System;
using System.Linq;

static class Program
{
    static int MaxPalindrome(this int[] a)
    {
        if (a.Count() == 1 || a.Count() == 0)
        {
            return a.Count();
        }

        if (a.First() == a.Last())
        {
            return 2 + a
                       .Skip(1)
                       .Take(a.Count() - 2)
                       .ToArray()
                       .MaxPalindrome();
        }

        return Math.Max(a
                        .Skip(1)
                        .ToArray()
                        .MaxPalindrome(),
                        a
                        .Take(a.Count() - 1)
                        .ToArray()
                        .MaxPalindrome());
    }

    static int MaxPalindrome2(this int[] a)
    {
        var n = a.Length;
        var dp = new int[n, n];
        for (var i = 0; i < n; i++)
        {
            dp[i, i] = 1;
        }

        for (var length = 2; length <= n; length++)
        {
            for (var start = 0; start <= n - length; start++)
            {
                var end = start + length - 1;
                dp[start, end] = a[start] == a[end] ?
                                    2 + dp[start + 1, end - 1] :
                                    Math.Max(
                                        dp[start, end - 1],
                                        dp[start + 1, end]);
            }
        }

        return dp[0, n - 1];
    }

    static void Main()
    {
        Console.WriteLine(
                "{0} - {1}",
                new [] { 1, 2, 4, 1 }.MaxPalindrome(),
                new [] { 1, 2, 4, 1 }.MaxPalindrome2());
    }
}
