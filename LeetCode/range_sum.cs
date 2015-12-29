//  This is my reimplementation of this problem here: https://leetcode.com/problems/range-sum-query-mutable/
//  Unfortunately if you do a segment tree implementation in C# the OJ will fail due to TLE. Bummmer.
//  I will try right now to implement it using start + length :)

using System;

public class Node 
{
    public int Start { get; set; }
    public int Length { get; set; }
    public int Sum { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public static Node Build(int[] a, int start, int length)
    {
        var result = new Node { 
            Start = start,
            Length = length
        };

        if (length == 1)
        {
            result.Sum = a[start];
            return result;
        }

        var half = length / 2;
        result.Left = Build(a, start, half);
        result.Right = Build(a, start + half, length - half);
        result.Sum = result.Left.Sum + result.Right.Sum;
        return result;
    }

    public override String ToString()
    {
        return String.Format(
                "[{0} - {1} = {2} {3} {4}]",
                Start,
                Length,
                Sum,
                Left == null ? "." : Left.ToString(),
                Right == null ? "." : Right.ToString());
    }
}

public class NumArray {
    private Node root;

    public NumArray(int[] nums) {
        root = Node.Build(nums, 0, nums.Length);
        Console.WriteLine(root);
    }

    public void Update(int i, int val) {
        Update(root, i, val);
    }

    private void Update(Node root, int position, int val)
    {
        if (root.Start == position && 
            root.Length == 1)
        {
            root.Sum = val;
            return;
        }

        var half = root.Length / 2;
        if (position <= root.Start + half)
        {
            Update(root.Left, position, val);
        }
        else
        {
            Update(root.Right, position, val);
        }

        root.Sum = root.Left.Sum + root.Right.Sum;
    }

    public int SumRange(int i, int j) {
        return SumRange(root, i, j - 1 + 1);  
    }

    private int SumRange(Node root, int start, int length)
    {
        if (root.Start == start &&
            root.Length == length)
        {
            return root.Sum;
        }

        var half = root.Length / 2;
        if (start >= root.Start + half) // segment is on the right side
        {
            return SumRange(root.Right, start, length);
        }
        else if (length <= half && start < root.Start + half) // segment is on the left side
        {
            return SumRange(root.Left, start, length);
        }

        // segment is 'segmented' between left and right - fucky
        return SumRange(start, root.Start + half - start) +
               SumRange(root.Start, length - (root.Start + half - start));
    }
}

class Solution
{
    static void Main()
    {
        NumArray numArray = new NumArray(new [] { 1, 2, 3, 4, 5, 6, 7, 8 });
        numArray.SumRange(1, 5);
        numArray.Update(1, 10);
        numArray.SumRange(1, 5);
    }
}
