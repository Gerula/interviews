//  https://leetcode.com/problems/majority-element-ii/
//  Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.
//  The algorithm should run in linear time and in O(1) space.

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public class Pair
    {
        public int Value { get; set; }
        public int Count { get; set; }
    }

    //  
    //  Submission Details
    //  64 / 64 test cases passed.
    //      Status: Accepted
    //      Runtime: 596 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  https://leetcode.com/submissions/detail/50653272/
    //
    public IList<int> MajorityElement(int[] nums) {
        var pairs = new List<Pair>();
        foreach (var num in nums)
        {
            if (pairs.Count < nums.Length / 3 + 3)
            {
                pairs.Add(new Pair { Value = num, Count = 1 });
                continue;
            }

            if (pairs.Any(x => x.Value == num))
            {
                pairs.First(x => x.Value == num).Count++;
                continue;
            }

            var toRemove = pairs.FirstOrDefault(x => x.Count == 0);
            if (toRemove != null)
            {
                toRemove.Value = num;
                toRemove.Count = 0;
            }
            else
            {
                foreach (var pair in pairs)
                {
                    pair.Count--;
                }
            }
        }

        return pairs 
               .Select(x => x.Value)
               .Distinct()
               .Where(x => nums.Count(y => y == x) > nums.Length / 3)
               .ToList();
    }

    static void Main()
    {
        var s = new Solution();
        var random = new Random();
        Console.WriteLine(String.Join(", ", s.MajorityElement(new [] { 1, 1, 1, 3, 3, 2, 2, 2 })));
        Console.WriteLine(String.Join(", ", s.MajorityElement(new [] { 2, 2, 1, 3 })));
        Console.WriteLine(String.Join(", ", s.MajorityElement(new [] { 4, 2, 1, 1 })));
        Console.WriteLine(String.Join(", ", s.MajorityElement(new [] { 1, 2 })));
        Console.WriteLine(String.Join(", ", s.MajorityElement(
                                                Enumerable
                                                .Repeat(1, 6)
                                                .Concat(
                                                    Enumerable
                                                    .Repeat(2, 6)
                                                    .Concat(
                                                        Enumerable
                                                        .Repeat(1, 4)
                                                        .Select(x => random.Next(10))))
                                                .OrderBy(x => random.Next())
                                                .ToArray())));
    }
}
