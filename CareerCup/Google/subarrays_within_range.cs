// http://careercup.com/question?id=5200686994161664
//
// Given an array of 32 bit integers return the number
// of non-empty subarrays whose sum lies between a and b
//

using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static int CountSubarrays(this int[] array, int a, int b)
    {
        int result = 0;
        var sums = array.Aggregate(new List<int>(), (agg, x) => {
                                        agg.Add(agg.LastOrDefault() + x);
                                        return agg;
                                   });

        result += sums.Count(x => a <= x && x <= b);

        sums = sums.OrderBy(x => x).ToList();
        var firstSums = sums.Take(sums.Count / 2);
        var secondSums = sums.Except(firstSums);
       
        result += firstSums.Select(x => secondSums.BinarySearch(a + x, (i, j) => i > j) - 
                                        secondSums.BinarySearch(a + x, (i, j) => i < j)).Sum();
        
        return result;
    }

    static int BinarySearch(this IEnumerable<int> collection, int border, Func<int, int, bool> comparer)
    {
        int low = 0;
        int high = collection.Count();

        while (low < high)
        {
            int mid = low + (high - low) / 2;
            int val = collection.ElementAt(mid);
            if (val == border)
            {
                return mid;
            }

            if (comparer(border, val))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    static void Main()
    {
        Console.WriteLine(new [] {1, 2, 3}.CountSubarrays(0, 3)); // 4 [1] [2] [3] [1, 2] [3]
        Console.WriteLine(new [] {-2, 5, -1}.CountSubarrays(-2, 2)); // 3 [-2] [-1] [-2, 5, 1]
    }
}
