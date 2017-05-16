//  http://qa.geeksforgeeks.org/7496/reverse-sums-problem
//
//  Let N be an integer. If N = 2536, the reversed N is 6352. If N = 1000000, the reversed N is 1.
//  So we are given an integer M, where 1<= M <= 10^(100000)
//
//  We need to find if an integer N exists, where N + reversed(N) = M

using System;

static class Solution
{
    static Tuple<bool, int, int> IsReverse(this int n)
    {
        for (var i = 0; i < n / 2; i++)
        {
            if (n == i + i.Reverse())
            {
                return Tuple.Create(true, i, i.Reverse());
            }
        }

        return Tuple.Create(false, 0, 0);
    }

    static int Reverse(this int n)
    {
        var result = 0;
        while (n != 0)
        {
            result = result * 10 + n % 10;
            n /= 10;
        }

        return result;
    }

    static void Main()
    {
        for (var i = 1000; i < 10000; i++)
        {
            var result = i.IsReverse();
            if (result.Item1)
            {
                Console.WriteLine("{0} = {1} + {2}", i, result.Item2, result.Item3);
            }
        }
    }
}
