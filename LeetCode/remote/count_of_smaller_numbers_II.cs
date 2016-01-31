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

        indexes = SortPairs(indexes).ToList();
        return Enumerable
               .Range(0, nums.Length)
               .Select(x => dictionary[x].Count)
               .ToList();
    }

    private IEnumerable<Pair> SortPairs(IEnumerable<Pair> nums)
    {
        var count = nums.Count();
        if (count < 2)
        {
            return nums;
        }

        return Merge(
                SortPairs(nums.Take(count / 2)),
                SortPairs(nums.Skip(count / 2)));
    }

    private IEnumerable<Pair> Merge(IEnumerable<Pair> first, IEnumerable<Pair> second)
    {
        var firstEnum = first.GetEnumerator();
        var secondEnum = second.GetEnumerator();
        bool anyFirst = firstEnum.MoveNext();
        bool anySecond = secondEnum.MoveNext();
        while (anyFirst && anySecond)
        {
            if (firstEnum.Current.Value > secondEnum.Current.Value)
            {
                firstEnum.Current.Count += secondEnum.Current.Count + 1;
                yield return firstEnum.Current;
                anyFirst = firstEnum.MoveNext();
            }
            else
            {
                yield return secondEnum.Current;
                anySecond = secondEnum.MoveNext();
            }
        }

        while (anyFirst)
        {
            yield return firstEnum.Current;
            anyFirst = firstEnum.MoveNext();
        }

        while (anySecond)
        {
            yield return secondEnum.Current;
            anySecond = secondEnum.MoveNext();
        }
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ", new Solution().CountSmaller(new [] { 5, 2, 6, 1 })));
    }
}
    
