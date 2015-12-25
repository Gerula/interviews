//  https://leetcode.com/problems/contains-duplicate-iii/
//
//  Given an array of integers,
//  find out whether there are two distinct indices i and j in the array such that the difference
//  between nums[i] and nums[j] is at most t and the difference between i and j is at most k. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        var set = new SortedDictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (set.Any() && set.Keys.Last() - set.Keys.First() <= t)
            {
                return true;
            }

            if (!set.ContainsKey(nums[i]))
            {
                set[nums[i]] = 0;
            }

            set[nums[i]]++;
            if (i >= k) 
            {
                set[nums[i - k]]--;

                if (set[nums[i - k]] == 0)
                {
                    set.Remove(nums[i - k]);
                }
            }
        }

        return false;
    }

    static void Main()
    {
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { 1, 2, 3, 4, 5, 6 }, 4, 3 ));
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { 1, 2, 3, 4, 5, 6 }, 4, -1 ));
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { 0 }, 0, 0 ));
        Console.WriteLine(new Solution().ContainsNearbyAlmostDuplicate(new [] { -3, 3 }, 2, 4 ));
    }
}
