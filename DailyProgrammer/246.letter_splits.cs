//  https://www.reddit.com/r/dailyprogrammer/comments/3xye4g/20151223_challenge_246_intermediate_letter_splits/
//
//  This problem is a simplified version of Text Segmentation in Natural Language Processing.
//
//  Description
//
//  Given a positive integer, return all the ways that the integer can be represented by letters using the mapping:
//
//      1 -> A
//      2 -> B
//
//      3 -> C
//
//       ...
//
//      25 -> Y
//
//      26 -> Z
//
//      For example, the integer 1234 can be represented by the words :
//
//      ABCD -> [1,2,3,4]
//      AWD -> [1,23,4]
//      LCD -> [12,3,4]

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static List<String> GetWords(this int[] a)
    {
        var n = a.Length;
        var dp = new List<String>[n + 1];
        dp[n] = new List<String> { String.Empty };
        for (var i = n - 1; i >= 0; i--)
        {
            var one = a[i].GetLetter();
            dp[i] = dp[i + 1].Select(x => one + x).ToList();
            if (i < n - 1 && a[i] * 10 + a[i + 1] < 27)
            {
                var two = (a[i] * 10 + a[i + 1]).GetLetter();
                dp[i].AddRange(dp[i + 2].Select(x => two + x));
            }
        }

        return dp[0];
    }

    static char GetLetter(this int a)
    {
        return (char)(a + 'A' - 1);
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, new [] { 1, 2, 3, 4 }.GetWords()));
        Console.WriteLine(String.Join(Environment.NewLine, "81161625815129412519419122516181571811313518".Select(x => (int)(x - '0')).ToArray().GetWords()));
    }
}
