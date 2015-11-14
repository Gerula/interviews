// https://leetcode.com/problems/insert-interval/
//
// Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
//
// You may assume that the intervals were initially sorted according to their start times.
//
// Example 1:
// Given intervals [1,3],[6,9], insert and merge [2,5] in as [1,5],[6,9].
//
// Example 2:
// Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] in as [1,2],[3,10],[12,16].
//
// This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10]. 
//
// 
// Submission Details
// 151 / 151 test cases passed.
//  Status: Accepted
//  Runtime: 568 ms
//      
//      Submitted: 0 minutes ago
// 
// 2 errors
// - IList fixed size (probably array)
// - Overlaps needs to be commutative 

using System;
using System.Collections.Generic;
using System.Linq;

public class Interval {
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
    public override String ToString()
    {
        return String.Format("[{0}, {1}] ", start, end);
    }
}

public class Solution {
    public static IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
        intervals = intervals.ToList();
        intervals.Add(newInterval);
        var result = new List<Interval>();
        result.AddRange(intervals.Where(x => x.end < newInterval.start));
        result.Add(intervals
                    .Where(x => Overlaps(x, newInterval) || Overlaps(newInterval, x))
                    .Aggregate(new Interval(int.MaxValue, int.MinValue),
                              (acc, x) => {
                                    acc.start = Math.Min(acc.start, x.start);
                                    acc.end = Math.Max(acc.end, x.end);
                                    return acc;
                              }));
        result.AddRange(intervals.Where(x => x.start > newInterval.end));
        return result;
    }

    static bool Overlaps(Interval a, Interval b)
    {
        return b.start <= a.start && a.start <= b.end ||
               b.start <= a.end && a.end <= b.end;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", Insert(new List<Interval> {
                            new Interval(1, 5)
                        }, new Interval(2, 3))));

        Console.WriteLine(String.Join(", ", Insert(new List<Interval> {
                            new Interval(1, 3),
                            new Interval(6, 9)
                        }, new Interval(2, 5))));

        Console.WriteLine(String.Join(", ", Insert(new List<Interval> {
                            new Interval(1, 2),
                            new Interval(3, 5),
                            new Interval(6, 7),
                            new Interval(8, 10),
                            new Interval(12, 16),
                        }, new Interval(4, 9))));
    }
}
