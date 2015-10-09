// https://www.reddit.com/r/dailyprogrammer/comments/3nkanm/20151005_challenge_235_easy_ruthaaron_pairs/
//
// In mathematics, a Ruth–Aaron pair consists of two consecutive integers (e.g. 714 and 715) for which the sums of the distinct prime factors of each integer are equal. For example, we know that (714, 715) is a valid Ruth-Aaron pair because its distinct prime factors are:
// 
// 714 = 2 * 3 * 7 * 17
// 715 = 5 * 11 * 13
// 
// and the sum of those is both 29:
// 
// 2 + 3 + 7 + 17 = 5 + 11 + 13 = 29

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static IEnumerable<int> Factors(this int x)
    {
        int limit = x;
        for (int i = 2; i <= limit; i++)
        {
            if (x % i == 0)
            {
                while (x % i == 0)
                {
                    x /= i;
                }

                yield return i;
            }
        }
    }

    static bool PairWith(this int a, int b)
    {
        return a.Factors().Sum() == b.Factors().Sum();
    }

    static void Main()
    {
        Tuple<int, int, bool>[] input = new [] {
            Tuple.Create(714, 715, true),
            Tuple.Create(77, 78, true),
            Tuple.Create(20, 21, false),
            Tuple.Create(5, 6, true),
            Tuple.Create(2107, 2108, true),
            Tuple.Create(492, 493, true),
            Tuple.Create(128, 129, false)
        };

        if (input.Any(x => x.Item1.PairWith(x.Item2) != x.Item3)) 
        {
            throw new Exception("Fuck you");
        }

        Console.WriteLine("All appears to be well");
    }
}
