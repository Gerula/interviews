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
        var indexes = Enumerable.
                        Repeat(0, a.Length).ToArray();
        
        result[0] = 1;
        for (int i = 1; i < n; i++)
        {
            result[i] = indexes.Select((x, index) => result[x] * a[index]).Min();
            indexes.
            Select((val, index) => 
            new { val, index}).
            Where(x => result[x.val] * a[x.index] == result[i]).
            ToList().
            ForEach(y => indexes[y.index] ++);
        }
        
        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(",", new [] {2, 3}.NthExpressibleNumber(20)));
    }
}
