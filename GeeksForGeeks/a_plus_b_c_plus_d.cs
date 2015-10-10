// http://www.geeksforgeeks.org/find-four-elements-a-b-c-and-d-in-an-array-such-that-ab-cd/
//
// Given an array of distinct integers, find if there are two pairs (a, b) and (c, d) such that
// a+b = c+d, and a, b, c and d are distinct elements. If there are multiple answers, then print any of them.

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static Tuple<int, int, int, int> GetPairs(this IEnumerable<int> a)
    {
        var hash = new Dictionary<int, Tuple<int, int>>();
        var result = Tuple.Create(-1, -1, -1, -1); 
        a.Zip(a.Skip(1), (first, second) => new {first, second}).
            ToList().
            ForEach((x) => {
                    int sum = x.first + x.second;
                    if (hash.ContainsKey(sum)) {
                        result = Tuple.Create(hash[sum].Item1,
                                            hash[sum].Item2,
                                            x.first,
                                            x.second);
                    }
                    else
                    {
                        hash[sum] = Tuple.Create(x.first, x.second);
                    }
                });

        return result;
    }

    static void Main()
    {
        var result = new [] {3, 4, 7, 1, 2, 9, 8}.ToList().GetPairs();
        Console.WriteLine("{0} + {1} == {2} + {3}", result.Item1, result.Item2, result.Item3, result.Item4);
    }
}
