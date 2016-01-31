//  https://leetcode.com/problems/count-of-smaller-numbers-after-self/
//
//   You are given an integer array nums and you have to return a new counts array.
//   The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].
//
//   Example:
//
//   Given nums = [5, 2, 6, 1]
//
//   To the right of 5 there are 2 smaller elements (2 and 1).
//   To the right of 2 there is only 1 smaller element (1).
//   To the right of 6 there is 1 smaller element (1).
//   To the right of 1 there is 0 smaller element.
//
//   Return the array [2, 1, 1, 0]. 

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    class Pair
    {
        public int Index { get; set; }
        public int Value { get; set; }
        public int Count { get; set; }
        public override String ToString()
        {
            return String.Format("[val : {0}, cnt: {1}, idx: {2}]", Value, Count, Index);
        }
    }

    public IList<int> CountSmaller(int[] nums)
    {
        var indexes = nums
                      .Select((val, index) => new Pair { Index = index, Value = val })
                      .ToList();
        var dictionary = indexes
                         .Aggregate(
                                 new Dictionary<int, Pair>(),
                                 (acc, x) => {
                                    acc[x.Index] = x;
                                    return acc;
                                 });

        SortPairs(indexes, 1 << 30);
        Console.WriteLine(String.Join(", ", indexes.Select(x => x.ToString())));
        return Enumerable
               .Range(0, nums.Length)
               .Select(x => dictionary[x].Count)
               .ToList();
    }

    private void SortPairs(List<Pair> nums, int mask)
    {
        if (nums.Count <= 1 || mask == 0)
        {
            return;
        }

        var smaller = new List<Pair>();
        var larger = new List<Pair>();
        var bit = mask < 0 ? 0 : mask;
        foreach (var x in nums)
        {
            if ((x.Value & mask) == bit)
            {
                x.Count += smaller.Count;
                larger.Add(x);        
            }
            else
            {
                smaller.Add(x);
            }
        }

        SortPairs(smaller, mask >> 1);
        SortPairs(larger, mask >> 1);
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().CountSmaller(new [] { 5, 2, 6, 1 })));
    }
}
    
