//  Given n dice each with m faces, numbered from 1 to m,
//  find the number of ways to get sum X.
//
//  X is the summation of values on each face when all the dice are thrown.

using System;
using System.Linq;

static class Program
{
    static int Ways(this int sum, int n, int m)
    {
        if (n == 0)
        {
            return sum == n ? 1 : 0;
        }

        return Enumerable
               .Range(1, m)
               .Select(x => (sum - x).Ways(n - 1, m))
               .Sum();
    }

    static int WaysDp(this int sum, int n, int m)
    {
        if (sum < n)
        {
            return 0;
        }

        var dp = new int[n + 1, sum + 1];
        for (var i = 1; i <= m; i++)
        {
            dp[1, i] = 1;
        }

        for (var i = 2; i <= n; i++)
        {
            for (var j = 1; j <= sum; j++)
            {
                for  (var k = 1; k <= m && k < j; k++)
                {
                    dp[i, j] += dp[i - 1, j - k];
                }
            }
        }

        return dp[n, sum];
    }

    static void Main()
    {
        foreach (var x in new [] { 
                    Tuple.Create(4, 2, 1, 0),
                    Tuple.Create(2, 2, 3, 2),
                    Tuple.Create(6, 3, 8, 21), 
                    Tuple.Create(4, 2, 5, 4),
                    Tuple.Create(4, 3, 5, 6),
                })
        {
            var dices = x.Item2;
            var m = x.Item1;
            var sum = x.Item3;
            var expected = x.Item4;
            var result = sum.Ways(dices, m);
            var dpResult = sum.WaysDp(dices, m);
            Console.WriteLine(
                    "Sum {0} Dice {1} Faces {2} [Expected {3} Actual {4} Dp {5}]",
                    sum, 
                    dices,
                    m,
                    expected,
                    result,
                    dpResult);
        }
    }
}
