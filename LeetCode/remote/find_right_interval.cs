//  https://leetcode.com/problems/find-right-interval/
//  https://leetcode.com/submissions/detail/83971575/
//
//  Submission Details
//  15 / 15 test cases passed.
//      Status: Accepted
//      Runtime: 745 ms
//          Submitted: 1 minute ago
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
    public int[] FindRightInterval(Interval[] intervals) {
        var timeLine = intervals.Select((value, index) => new [] {
                new {Idx = index, Value = value.start, Type = 0},
                new {Idx = index, Value = value.end, Type = 1}})
                .SelectMany(x => x)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Type);

        var result = Enumerable.Repeat(-1, intervals.Length).ToArray();
        var lastStart = -1;
        foreach (var x in timeLine) 
        {
            switch (x.Type) {
                case 0: lastStart = x.Idx; break;
                case 1: result[x.Idx] = lastStart; break;
            }
        }

        return result;
    }
}
