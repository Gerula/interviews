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
            Console.WriteLine(
                    "Sum {0} Dice {1} Faces {2} [Expected {3} Actual {4}]",
                    sum, 
                    dices,
                    m,
                    expected,
                    result);
        }
    }
}
