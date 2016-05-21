//  http://www.geeksforgeeks.org/check-if-a-number-is-bleak/
//  A number ‘n’ is called Bleak if it cannot be represented as sum of a positive number x and set bit count in x, i.e.,
//  x + countSetBits(x) is not equal to n for any non-negative number x.

using System;
using System.Linq;

static class Solution
{
    static bool IsBleak(this int n)
    {
        return Enumerable.Range(1, n - 1).All(x => x + x.SetBits() != n);
    }

    static int SetBits(this int n)
    {
        var count = 0;
        while (n != 0)
        {
            n &= n - 1;
            count++;
        }

        return count;
    }

    static void Main()
    {
        Console.WriteLine(3.IsBleak());
        Console.WriteLine(4.IsBleak());
    }
}
