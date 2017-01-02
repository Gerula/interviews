//  https://leetcode.com/problems/insert-interval/
//  https://leetcode.com/submissions/detail/87604007/

/**
 * Definition for an interval.
 * public class Interval {
 *     public int start;
 *     public int end;
 *     public Interval() { start = 0; end = 0; }
 *     public Interval(int s, int e) { start = s; end = e; }
 * }
 */
public class Solution {
    public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval) {
        return intervals
               .Where(x => !Intersects(x, newInterval) && x.end < newInterval.start)
               .Concat(intervals
                       .Where(x => Intersects(x, newInterval))
                       .Aggregate(new [] { newInterval }.ToList(), (acc, x) => {
                          acc[acc.Count - 1] = new Interval(
                              Math.Min(x.start, acc[acc.Count - 1].start),
                              Math.Max(x.end, acc[acc.Count - 1].end));
                          return acc;
                       }))
               .Concat(intervals
                       .Where(x => !Intersects(x, newInterval) && x.start > newInterval.end))
               .ToList();
    }

    private bool Intersects(Interval a, Interval b) {
        // x1 <= c <= y1
        // x2 <= c <= y2
        // x1 <= y2 && x2 <= y1
        return a.start <= b.end && b.start <= a.end;
    }
}
