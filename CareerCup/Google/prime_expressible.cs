// http://careercup.com/question?id=4816567298686976
//
// (Careercup really needs to step up their copy-paste game)
//
// Given a prime set, we call "prime expressible" if a number can be factorized only using given prime numbers.
// Find n-th big expressible number. 
//
// Example:
// Set = { 2, 3 }
//
// Expressible numbers = { 1, 2, 3, 4, 6, 8, 9, 12, ... }
//

using System;
using System.Linq;

static class Program 
{
    static int[] NthExpressibleNumber(this int[] a, int n)
    {
        var result = new int[n];
        result[0] = 1;
        for (int i = 1; i < n; i++)
        {
            result[i] = a.Select(x => result[i - 1] * x).Min();
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(",", new [] {2, 3}.NthExpressibleNumber(20)));
    }
}
