//  https://leetcode.com/problems/next-permutation/
//  Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.
//
//  If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).
//
//  The replacement must be in-place, do not allocate extra memory.
//
//  Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
//  1,2,3 → 1,3,2
//  3,2,1 → 1,2,3
//  1,1,5 → 1,5,1
//

using System;

public class Solution {
    // 
    // Submission Details
    // 265 / 265 test cases passed.
    //  Status: Accepted
    //  Runtime: 484 ms
    //      
    //      Submitted: 0 minutes ago
    //
    public void NextPermutation(int[] nums) {
        var n = nums.Length;
        if (nums.Length == 1)
        {
            return;
        }

        var last = n - 2;
        while (last >= 0 && nums[last] >= nums[last + 1])
        {
            last--;
        }

        if (last == -1)
        {
            Reverse(nums, 0, n - 1);
            return;
        }

        var first = n - 1;
        while (first > last && nums[first] <= nums[last])
        {
            first--;
        }

        Swap(nums, first, last);
        Reverse(nums, last + 1, n - 1);
    }

    public void Reverse(int[] nums, int i, int j)
    {
        while (i < j)
        {
            Swap(nums, i++, j--);
        }
    }

    public void Swap(int[] nums, int i, int j)
    {
        var c = nums[i];
        nums[i] = nums[j];
        nums[j] = c;
    }

    static void Main()
    {
        var s = new Solution();
        var a = new [] { 1, 2, 3 };
        Console.Write("{0} -> ", String.Join(", ", a));
        s.NextPermutation(a);
        Console.WriteLine("{0}", String.Join(", ", a));
        a = new [] { 3, 2, 1 };
        Console.Write("{0} -> ", String.Join(", ", a));
        s.NextPermutation(a);
        Console.WriteLine("{0}", String.Join(", ", a));
        a = new [] { 1, 1, 5 };
        Console.Write("{0} -> ", String.Join(", ", a));
        s.NextPermutation(a);
        Console.WriteLine("{0}", String.Join(", ", a));
        a = new [] { 1, 5, 1 };
        Console.Write("{0} -> ", String.Join(", ", a));
        s.NextPermutation(a);
        Console.WriteLine("{0}", String.Join(", ", a));
        a = new [] { 5, 1, 1 };
        Console.Write("{0} -> ", String.Join(", ", a));
        s.NextPermutation(a);
        Console.WriteLine("{0}", String.Join(", ", a));
    }
}
