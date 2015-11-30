// http://careercup.com/question?id=5172027535130624
//
// Print all continuous subseq which sum to 0.
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static List<Tuple<int, int>> SumZero(this int[] a)
    {
        var sums = a
                   .Skip(1)
                   .Aggregate(
                        new List<int> { a[0] },
                        (acc, x) => 
                        {
                            acc.Add(acc.Last() + x);
                            return acc;
                        });

        var hash = new Dictionary<int, int>();
        return sums
               .Select((item, index) => new { Item = item, Index = index })
               .Aggregate(
                       new List<Tuple<int, int>>(),
                       (acc, x) => {
                            if (hash.ContainsKey(x.Item))
                            {
                                acc.Add(Tuple.Create(hash[x.Item] + 1, x.Index));    
                            }
                            else if (x.Item == 0)
                            {
                                acc.Add(Tuple.Create(0, x.Index));
                            }

                            hash[x.Item] = x.Index;
                            return acc;
                       });
    }

    static void Main()
    {
        Console.WriteLine(String.Join(",", new [] { -1, -3, 4, 5, 4, -9, 3, -3 }.SumZero()));
    }
}
