//  http://buttercola.blogspot.com/2015/08/leetcode-missing-ranges.html
//
//   Given a sorted integer array where the range of elements are [lower, upper] inclusive, return its missing ranges.
//   For example, given [0, 1, 3, 50, 75], lower = 0 and upper = 99, return ["2", "4->49", "51->74", "76->99"].

using System;
using System.Collections.Generic;
using System.Linq;

static class Solution
{
    static List<String> Missing(this List<int> nums, int low, int high)
    {
        var previous = low;
        var result = new List<String>();
        foreach (var x in nums)
        {
            if (low > x)
            {
                continue;
            }

            if (x - previous >= 2)
            {
                var first = previous + 1;
                var second = x - 1;
                result.Add(first == second ? first.ToString() : String.Format("{0} -> {1}", first, second));
            }
            
            if (high < x)
            {
                var first = previous + 1;
                var second = high + 1;
                result.Add(first == second ? first.ToString() : String.Format("{0} -> {1}", first, second));
                break;
            }

            previous = x;
        }

        return result;
    }

    static void Main()
    {
        var r = new Random();
        var times = r.Next(10);
        for (var i = 0; i < times; i++)
        {
            var count = r.Next(20);
            var a = Enumerable
                    .Repeat(0, count)
                    .Aggregate(
                            new List<int>(),
                            (acc, x) => {
                                if (!acc.Any())
                                {
                                    acc.Add(x);
                                    return acc;
                                }

                                acc.Add(acc.Last() + (r.Next(1, 10) % 2 == 0 ? r.Next(1, 10) : 1));
                                return acc;
                            });

            var low = r.Next(1, count);
            var high = r.Next(low, count);
            Console.WriteLine(String.Format(
                        "{0} - low {1} high {2} - {3} ",
                        String.Join(", ", a),
                        low,
                        high,
                        String.Join(", ", a.Missing(low, high))));
        }
    }
}
