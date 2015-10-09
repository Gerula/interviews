// http://www.geeksforgeeks.org/sort-elements-by-frequency/
//
// Print the elements of an array in the decreasing frequency if 2 numbers have same frequency then print the one which came first.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static IEnumerable<int> SortByFreq(this int[] a)
    {
        var occurences = new Dictionary<int, int>();
        var hash = a.
                    Select((item, index) => new { val = item, idx = index }).
                    Aggregate(new Dictionary<int, int>(), (acc, x) => {
                                if (!occurences.ContainsKey(x.val))
                                {
                                    occurences[x.val] = x.idx;
                                }

                                if (!acc.ContainsKey(x.val)) 
                                {
                                    acc[x.val] = 0;
                                }

                                acc[x.val]++;
                                return acc;
                            });

        return hash.
                OrderBy(x => x.Value).
                ThenByDescending(z => occurences[z.Key]).
                Reverse().
                SelectMany(y => Enumerable.Repeat(y.Key, hash[y.Key]));
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new [] {2, 5, 2, 8, 5, 6, 8, 8}.SortByFreq()));
        Console.WriteLine(String.Join(", ", new [] {2, 5, 2, 6, -1, 999, 5, 8, 8, 8}.SortByFreq()));
    }
}
