//  https://leetcode.com/problems/count-of-smaller-numbers-after-self/
//
//  You are given an integer array nums and you have to return a new counts array.
//  The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i]. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<int> CountSmall(int[] nums)
    {
        var result = new List<int>();
        var numList = new List<int>();
        foreach (var num in nums.Reverse())
        {
            var idx = FindPosition(numList, num);
            numList.Insert(idx, num);
            result.Add(idx);
        }

        result.Reverse();
        return result;
    }

    int FindPosition(List<int> list, int element)
    {
        if (list.Count == 0)
        {
            return 0;
        }

        if (element <= list.First())
        {
            return 0;
        }

        if (element >= list.Last())
        {
            return list.Count;
        }

        var low = 0;
        var high = list.Count;
        while (low < high)
        {
            var mid = low + (high - low) / 2;
            if (element >= list[mid])
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }

    public IList<int> CountSmaller(int[] nums) {
        var counts = nums.Aggregate(
                new Dictionary<int, int>(),
                (acc, x) => {
                    acc[x] = 0;
                    return acc;
                });

        Sort(nums.ToArray(), 0, nums.Length, counts);
        return nums
               .Select(x => counts[x])
               .ToList();
    }

    void Sort(int[] nums, int start, int length, Dictionary<int, int> counts)
    {
        if (length < 2)
        {
            return;
        }

        Sort(nums, start, length / 2, counts);
        Sort(nums, start + length / 2, length - length / 2, counts);
        var sorted = new List<int>();
        var i = start;
        var j = start + length / 2;
        while (i < start + length / 2 && j < start + length)
        {
            if (nums[i] > nums[j])
            {
                sorted.Add(nums[i]);
                counts[nums[i++]] += start + length - j;
            }
            else
            {
                sorted.Add(nums[j++]);
            }
        }

        while (i < start + length / 2)
        {
            sorted.Add(nums[i++]);
        }
        while (j < start + length)
        {
            sorted.Add(nums[j++]);
        }

        Array.Copy(sorted.ToArray(), 0, nums, start, length);
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(String.Join(", ", s.CountSmaller(new [] { 5, 2, 6, 1 })));
        Console.WriteLine(String.Join(", ", s.CountSmaller(new [] { 2, 0, 1 })));
        Console.WriteLine(String.Join(", ", s.CountSmaller(new [] { 1, 2, 7, 8, 5 })));
        Console.WriteLine(String.Join(", ", s.CountSmaller(new [] { 26,78,27,100,33,67,90,23,66,5,38,7,35,23,52,22,83,51,98,69,81,32,78,28,94,13,2,97,3,76,99,51,9,21,84,66,65,36,100,41})));
        Console.WriteLine(String.Join(", ", s.CountSmall(new [] { 5, 2, 6, 1 })));
        Console.WriteLine(String.Join(", ", s.CountSmall(new [] { 2, 0, 1 })));
        Console.WriteLine(String.Join(", ", s.CountSmall(new [] { 1, 2, 7, 8, 5 })));
        Console.WriteLine(String.Join(", ", s.CountSmall(new [] { 26,78,27,100,33,67,90,23,66,5,38,7,35,23,52,22,83,51,98,69,81,32,78,28,94,13,2,97,3,76,99,51,9,21,84,66,65,36,100,41})));
    }
}
