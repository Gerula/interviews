//  https://leetcode.com/problems/create-maximum-number/
//
//   Given two arrays of length m and n with digits 0-9 representing two numbers. Create the maximum number of length k <= m + n from digits of the two. The relative order of the digits from the same array must be preserved. Return an array of the k digits. You should try to optimize your time and space complexity.
//
//   Example 1:
//
//   nums1 = [3, 4, 6, 5]                   3   4   6   5
//   nums2 = [9, 1, 2, 5, 8, 3]         9   9   9   9   9   
//   k = 5                              1   3   4   6   5
//   return [9, 8, 6, 5, 3]             2   3   4   6   5
//                                      5   5   5   6   5
//   Example 2:                         8   8   8   8   8
//                                      3   3   4   6   5
//   nums1 = [6, 7]
//   nums2 = [6, 0, 4]
//   k = 5
//   return [6, 7, 6, 0, 4]
//
//   Example 3:
//
//   nums1 = [3, 9]
//   nums2 = [8, 9]
//   k = 3
//   return [9, 8, 9] 

using System;
using System.Linq;

public class Solution {
    public int[] MaxNumber(int[] nums1, int[] nums2, int k) {
        var dp = new int [nums1.Length + 1, nums2.Length + 1, k + 1];
        
        for (var i = 0; i <= k; i++)
        {
            for (var a = 0; a <= nums1.Length; a++)
            {
                for (var b = 0; b <= nums2.Length; b++)
                {
                    if (i == 0 || a == 0 && b == 0)
                    {
                        dp[a, b, i] = 0;
                        continue;
                    }
                    
                    if (a == 0)
                    {
                        dp[a, b, i] = Math.Max(nums2[b - 1] + dp[0, b - 1, i - 1] * 10, dp[0, b - 1, i]);
                        continue;
                    }

                    if (b == 0)
                    {
                        dp[a, b, i] = Math.Max(nums1[a - 1] + dp[a - 1, 0, i - 1] * 10, dp[a - 1, 0, i]);
                        continue;
                    }

                    dp[a, b, i] = Math.Max(
                                    dp[a - 1, b - 1, i] * 10,
                                    Math.Max(
                                        nums1[a - 1] + dp[a - 1, b, i - 1] * 10,
                                        nums2[b - 1] + dp[a, b - 1, i - 1] * 10));
                }
            }
        }

        return dp[nums1.Length, nums2.Length, k]
               .ToString()
               .Select(x => x - '0')
               .Take(k)
               .ToArray();
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(String.Join(", ", s.MaxNumber(new [] { 3, 4, 6, 5 }, new [] { 9, 1, 2, 5, 8, 3 }, 5)));
        Console.WriteLine(String.Join(", ", s.MaxNumber(new [] { 6, 7 }, new [] { 6, 0, 4 }, 5)));
        Console.WriteLine(String.Join(", ", s.MaxNumber(new [] { 3, 9 }, new [] { 8, 9 }, 3)));
    }
}
