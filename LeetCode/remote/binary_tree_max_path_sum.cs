//  https://leetcode.com/problems/binary-tree-maximum-path-sum/
//
//   Given a binary tree, find the maximum path sum.
//
//   For this problem, a path is defined as any sequence of nodes
//   from some starting node to any node in the tree along the parent-child connections.
//   The path does not need to go through the root.

using System;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    //  
    //  Submission Details
    //  92 / 92 test cases passed.
    //      Status: Accepted
    //      Runtime: 204 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public int MaxPathSum(TreeNode root) {
        var result = int.MinValue;
        Max(root, ref result);
        return result;
    }

    public int Max(TreeNode root, ref int result)
    {
        var left = root.left == null ? 0 : Max(root.left, ref result);
        var right = root.right == null ? 0 : Max(root.right, ref result);
        left = left < 0 ? 0 : left;
        right = right < 0 ? 0 : right;
        result = Math.Max(result, left + right + root.val);
        return root.val + Math.Max(left, right);
    }

    static void Main()
    {
        Console.WriteLine(new Solution().MaxPathSum(new TreeNode(1) {
                        left = new TreeNode(2),
                        right = new TreeNode(3)
                    }));
        Console.WriteLine(new Solution().MaxPathSum(new TreeNode(2) {
                        left = new TreeNode(-1)
                    }));
    }
}
