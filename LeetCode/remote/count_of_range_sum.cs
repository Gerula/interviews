//  https://leetcode.com/problems/count-of-range-sum/
//
//   Given an integer array nums, return the number of range sums that lie in [lower, upper] inclusive.
//   Range sum S(i, j) is defined as the sum of the elements in nums between indices i and j (i ≤ j), inclusive.
//
//   Note:
//   A naive algorithm of O(n2) is trivial. You MUST do better than that. 

using System;
using System.Linq;

public class TreeNode
{
    public int Count { get; set; }
    public long Min { get; set; }
    public long Max { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }

    public static TreeNode Build(long[] a, int low, int high)
    {
        if (low > high)
        {
            return null;
        }

        if (low == high)
        {
            return new TreeNode 
            { 
                Min = a[low], 
                Max = a[high]
            };
        }

        var mid = low + (high - low) / 2;
        return new TreeNode 
        { 
            Min = a[low], 
            Max = a[high],
            Left = Build(a, low, mid),
            Right = Build(a, mid + 1, high)
        };
    }

    public void UpdateCount(long val)
    {
        if (Min <= val && val <= Max)
        {
            Count++;
            if (Left != null)
            {
                Left.UpdateCount(val);
            }
            if (Right != null)
            {
                Right.UpdateCount(val);
            }
        }
    }

    public int ReadCount(long min, long max)
    {
        if (min > Max || max < Min)
        {
            return 0;
        }

        if (min <= Min && max >= Max)
        {
            return Count;
        }

        return (Left == null ? 0 : Left.ReadCount(min, max)) + 
               (Right == null ? 0 : Right.ReadCount(min, max));
    }
}

public class Solution {
    public int CountRangeSum2(int[] nums, int lower, int upper) {
        var newNums = new long[nums.Length];
        long sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            newNums[i] = (long) nums[i];
            sum += newNums[i];
        }
        Array.Sort(newNums);
        var tree = TreeNode.Build(newNums, 0, newNums.Length - 1);
        var result = 0;
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            tree.UpdateCount(sum);
            sum -= nums[i];
            result += tree.ReadCount((long) lower + sum, (long) upper + sum);
        }

        return result;
    }

    public int CountRangeSum(int[] nums, int lower, int upper) {
        var n = nums.Length;
        var pre = new int[n];
        pre[0] = nums[0];
        for (var i = 1; i < n; i++)
        {
            pre[i] = pre[i - 1] + nums[i];
        }

        var count = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                var sum = pre[j] - pre[i] + nums[j];
                if (lower <= sum && sum <= upper)
                {
                    count++;
                }
            }
        }

        return count;
    }

    static void Main()
    {
        var s = new Solution();
        Console.WriteLine(s.CountRangeSum(new [] { -2, 5, -1 }, -2, 2));
        Console.WriteLine(s.CountRangeSum(new [] { -2, 5, -1 }, -1, 2));
        Console.WriteLine(s.CountRangeSum2(new [] { -2, 5, -1 }, -2, 2));
        Console.WriteLine(s.CountRangeSum2(new [] { -2, 5, -1 }, -1, 2));
    }
}
