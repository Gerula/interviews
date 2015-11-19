// https://leetcode.com/problems/range-sum-query-mutable/
// 
// Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
// The update(i, val) function modifies nums by updating the element at index i to val.
//
// Example:
//
// Given nums = [1, 3, 5]
//
// sumRange(0, 2) -> 9
// update(1, 2)
// sumRange(0, 2) -> 8
//
// Note:
//
// The array is only modifiable by the update function.
// You may assume the number of calls to update and sumRange function is distributed evenly.
//

using System;

public class NumArray {
    class TreeNode {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public int Sum { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public static TreeNode Construct(int[] a, int low, int high)
        {
            if (low > high)
            {
                return null;
            }

            var result = new TreeNode {
                Start = low, 
                End = high
            };

            if (low == high) 
            {
                result.Sum = a[low];
                return result;
            }

            var mid = low + (high - low) / 2;
            result.Left = Construct(a, low, mid);
            result.Right = Construct(a, mid + 1, high);
            result.Sum = result.Left.Sum + result.Right.Sum;
            return result;
        }
    }

    TreeNode root;

    public NumArray(int[] nums) 
    {
        root = TreeNode.Construct(nums, 0, nums.Length - 1);
    }

    public void Update(int i, int val) 
    {
        Update(root, i, val);        
    }

    public int SumRange(int i, int j) 
    {
        return SumRange(root, i, j);        
    }

    private void Update(TreeNode root, int i, int j)
    {
        if (root.Start == root.End)
        {
            root.Sum = j;
            return;
        }

        var mid = root.Start + (root.End - root.Start) / 2;
        if (i <= mid)
        {
            Update(root.Left, i, j);
        }
        else
        {
            Update(root.Right, i, j);
        }

        root.Sum = root.Left.Sum + root.Right.Sum;
    }

    private int SumRange(TreeNode root, int i, int j)
    {
        if (root.Start == i && root.End == j)
        {
            return root.Sum;
        }

        var mid = root.Start + (root.End - root.Start) / 2;
        if (j <= mid)
        {
            return SumRange(root.Left, i, j);
        }

        if (i >= mid + 1)
        {
            return SumRange(root.Right, i, j);
        }

        return SumRange(root.Left, mid + 1, j) + SumRange(root.Right, i, mid);
    }

    static void Main()
    {
        var a = new NumArray(new [] { 1, 3, 5});
        Console.WriteLine("sumRange(0, 2) = {0}", a.SumRange(0, 2));
        a.Update(1, 2);
        Console.WriteLine("sumRange(0, 2) = {0}", a.SumRange(0, 2));
    }
}

