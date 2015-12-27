//  https://leetcode.com/problems/3sum/
//
//  Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
//
//  Note:
//
//      Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
//      The solution set must not contain duplicate triplets.
//
//      For example, given array S = {-1 0 1 2 -1 -4},
//
//      A solution set is:
//      (-1, 0, 1)
//      (-1, -1, 2)

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    //  
    //  Submission Details
    //  311 / 311 test cases passed.
    //      Status: Accepted
    //      Runtime: 576 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          https://leetcode.com/submissions/detail/48992357/
    //
    public IList<IList<int>> ThreeSum(int[] nums) {
        var sorted = nums.OrderBy(x => x).ToArray();
        var result = new List<IList<int>>();
        for (var i = 0; i < sorted.Length - 1; i++)
        {
            if (i > 0 && sorted[i] == sorted[i - 1])
            {
                continue;
            }

            var low = i + 1;
            var high = sorted.Length - 1;
            while (low < high)
            {
                var sum = sorted[i] + sorted[low] + sorted[high];
                if (sum == 0)
                {
                    result.Add(new List<int> { sorted[i], sorted[low], sorted[high] });
                    while (low < sorted.Length - 1 && sorted[low] == sorted[low + 1])
                    {
                        low++;
                    }
                    while (high > low && sorted[high] == sorted[high - 1])
                    {
                        high--;
                    }

                    low++;
                    high--;
                }
                else if (sum < 0)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(
                String.Join(
                    Environment.NewLine,
                    new Solution()
                        .ThreeSum(new [] { -1, 0, 1, 2, -1, -4 })
                        .Select(x => String.Join(", ", x))));
    }
}
