//  https://leetcode.com/problems/maximum-gap/
//
//  Given an unsorted array, find the maximum difference between the successive elements in its sorted form.

using System;
using System.Collections.Generic;
using System.Linq;

class Solution {
    class Bucket 
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    public int MaximumGap(int[] nums) {
        if (nums.Length < 2)
        {
            return 0;
        }

        var min = nums.Min();
        var max = nums.Max();
        var bucketSize = (float) (max - min) / nums.Length;
        var buckets = new Dictionary<int, Bucket>();
        foreach (var x in nums)
        {
            var bucketId = (int)((x - min) / bucketSize);
            if (!buckets.ContainsKey(bucketId))
            {
                buckets[bucketId] = new Bucket { Min = x, Max = x };
            }
            else
            {
                buckets[bucketId].Min = Math.Min(buckets[bucketId].Min, x);
                buckets[bucketId].Max = Math.Max(buckets[bucketId].Max, x);
            }
        }

        Bucket prev = null;
        var maxGap = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (!buckets.ContainsKey(i))
            {
                continue;
            }

            if (prev == null)
            {
                prev = buckets[i];
                continue;
            }

            maxGap = Math.Max(maxGap, buckets[i].Min - prev.Max);
            prev = buckets[i];
        }

        return maxGap;
    }

    public int MaximumGapNaive(int[] nums) 
    {
        var ordered = nums.OrderBy(x => x).ToArray();
        var max = 0;
        for (var i = 0; i < ordered.Length - 2; i++)
        {
            max = Math.Max(ordered[i + 1] - ordered[i], max);
        }

        return max;
    }

    static void Main()
    {
        var random = new Random();
        var s = new Solution();
        var times = random.Next(1, 10);
        for (var i = 0; i < times; i++)
        {
            var vector = Enumerable
                         .Repeat(1, random.Next(10, 20))
                         .Select(x => random.Next(0, 100))
                         .ToArray();

            var good = s.MaximumGapNaive(vector);
            var iffy = s.MaximumGap(vector);
            if (good != iffy)
            {
                Console.WriteLine("For {0}. It should be {1} but it was {2}", String.Join(", ", vector), good, iffy);
            }
            else
            {
                Console.WriteLine("For {0}. It should be {1} and it was {2}.... OK!", String.Join(", ", vector), good, iffy);
            }
        }
    }
}
