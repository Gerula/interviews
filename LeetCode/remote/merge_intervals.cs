// https://leetcode.com/problems/merge-intervals/
//
// Given a collection of intervals, merge all overlapping intervals.
//
// For example,
// Given [1,3],[2,6],[8,10],[15,18],
// return [1,6],[8,10],[15,18]. 
//
// 
// Submission Details
// 168 / 168 test cases passed.
//  Status: Accepted
//  Runtime: 596 ms
//      
//      Submitted: 0 minutes ago
//

using System;
using System.Collections.Generic;
using System.Linq;

public class Interval 
{
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
    public override String ToString()
    {
        return String.Format("[{0}, {1}]", start, end);
    }
}

public class Solution {
    public static IList<Interval> Merge(IList<Interval> intervals) {
        if (intervals.Count == 0)
        {
            return intervals;
        }

        intervals = intervals.OrderBy(x => x.start).ToList();
        var result = new List<Interval> { intervals.First() };
        foreach (var interval in intervals)
        {
            var last = result.Last();
            if (Overlaps(last, interval) || Overlaps(interval, last))
            {
                last.start = Math.Min(last.start, interval.start);
                last.end = Math.Max(last.end, interval.end);
            }
            else
            {
                result.Add(interval);
            }
        }

        return result;
    }

    static bool Overlaps(Interval a, Interval b)
    {
        return b.start <= a.start && a.start <= b.end ||
               a.start <= b.start && b.start <= a.end;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", Merge(new List<Interval> {
                            new Interval(1, 3),
                            new Interval(2, 6),
                            new Interval(8, 10),
                            new Interval(15, 18)
                        })));
    }
}


