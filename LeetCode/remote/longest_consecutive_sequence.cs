//  https://leetcode.com/problems/longest-consecutive-sequence/
//
//   Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
//
//   For example,
//   Given [100, 4, 200, 1, 3, 2],
//   The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.
//
//   Your algorithm should run in O(n) complexity. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  67 / 67 test cases passed.
    //      Status: Accepted
    //      Runtime: 176 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/49442053/
    public int LongestConsecutive(int[] nums) {
        var hash = nums.Aggregate(new HashSet<int>(), (acc, x) => {
                    acc.Add(x);
                    return acc;
                });

        var maxLen = 0;
        foreach (var x in nums)
        {
            var low = x;
            while (hash.Contains(low))
            {
                hash.Remove(low);
                low--;
            }
            
            low++;
            var high = x + 1;
            while (hash.Contains(high))
            {
                hash.Remove(high);
                high++;
            }

            high--;
            maxLen = Math.Max(high - low + 1, maxLen);
        }

        return maxLen;
    }

    //  https://leetcode.com/submissions/detail/67124592/
    //
    //  Submission Details
    //  67 / 67 test cases passed.
    //      Status: Accepted
    //      Runtime: 180 ms
    //          
    //          Submitted: 1 minute ago
    public int LongestConsecutive(int[] nums) {
        var presence = new HashSet<int>(nums);
        return nums.Aggregate(
            0,
            (max, x) => {
               if (!presence.Contains(x)) {
                   return max;
               }
               
               var length = 1;
               presence.Remove(x);
               var low = x - 1;
               while (presence.Contains(low)) {
                   presence.Remove(low);
                   length++;
                   low--;
               }
               
               var high = x + 1;
               while (presence.Contains(high)) {
                   presence.Remove(high);
                   length++;
                   high++;
               }
               
               return Math.Max(length, max);
            });
    }

    static void Main()
    {
        Console.WriteLine(new Solution().LongestConsecutive(new [] { 100, 4, 200, 1, 3, 2 }));
    }
}
