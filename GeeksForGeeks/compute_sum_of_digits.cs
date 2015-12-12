//  http://www.geeksforgeeks.org/count-sum-of-digits-in-numbers-from-1-to-n/
//
//  Given a number x, find sum of digits in all numbers from 1 to n.
//  Examples:
//
//  Input: n = 5
//  Output: Sum of digits in numbers from 1 to 5 = 15
//
//  Input: n = 12
//  Output: Sum of digits in numbers from 1 to 12 = 51
//
//  Input: n = 328
//  Output: Sum of digits in numbers from 1 to 328 = 3241
//

using System;
using System.Linq;

static class Solution
{
    static int Sum(this int n)
    {
        var dp = new int[n + 1];
        return Enumerable
               .Range(1, n)
               .Aggregate(0, (acc, x) => {
                            return acc + (x < 10 ? dp[x] = x : dp[x] = dp[x / 10] + x % 10);
                       });
    }

    static int Sum2(this int n)
    {
        return Enumerable
               .Range(1, n)
               .Aggregate(0, (acc, x) => {
                            while (x > 0)
                            {
                                acc += x % 10;
                                x /= 10;
                            }

                            return acc;
                       });
    }

    static void Main()
    {
        Console.WriteLine(5.Sum());
        Console.WriteLine(12.Sum());
        Console.WriteLine(328.Sum());
        Console.WriteLine(3328.Sum());
        Console.WriteLine(5.Sum2());
        Console.WriteLine(12.Sum2());
        Console.WriteLine(328.Sum2());
        Console.WriteLine(99333328.Sum2());
    }
}
