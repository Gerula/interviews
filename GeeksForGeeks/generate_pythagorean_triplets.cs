// http://www.geeksforgeeks.org/generate-pythagorean-triplets/
//
// A Pythagorean triplet is a set of three integers a, b and c such that a2 + b2 = c2.
//
// Given a limit, generate all positive Pythagorean triplets such that all values in triplets are smaller than given limit.
//
// Example:
//
// Input: limit = 10
// Output: 3 4 -> 5
//         8 6 -> 10
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static IEnumerable<Tuple<int, int, int>> Pythagoras(this int n)
    {
        for (int i = 1; i <= n; i++)
            for (int j = i + 1; j <= n; j++)
                for (int k = j + 1; k <= n; k++)
                {
                    if (i * i + j * j == k * k)
                    {
                        yield return Tuple.Create(i, j, k);
                    }
                }
    }

    static void Main()
    {
        for (int i = 6; i < 30; i++)
        {
            Console.WriteLine(String.Join(", ",
                                          i.Pythagoras().Select(x => String.Format("{0}^2 + {1}^2 = {2}^2",
                                                                                    x.Item1, 
                                                                                    x.Item2, 
                                                                                    x.Item3))));
        }
    }
}
