//  https://leetcode.com/problems/binary-tree-postorder-traversal/
//
//  Given a binary tree, return the postorder traversal of its nodes' values.
//
//  Note: Recursive solution is trivial, could you do it iteratively?

using System;
using System.Collections.Generic;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    //  
    //  Submission Details
    //  67 / 67 test cases passed.
    //      Status: Accepted
    //      Runtime: 488 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public IList<int> PostorderTraversal(TreeNode root) {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        TreeNode lastNodeVisited = null;
        while (stack.Count > 0 || root != null)
        {
            if (root != null)
            {
                stack.Push(root);
                root = root.left;
            }
            else
            {
                var peek = stack.Peek();
                if (peek.right != null && peek.right != lastNodeVisited)
                {
                    root = peek.right;
                }
                else
                {
                    result.Add(peek.val);
                    lastNodeVisited = stack.Pop();
                }
            }
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(", ",
                new Solution()
                .PostorderTraversal(
                    new TreeNode(1) {
                        right = new TreeNode(2) {
                            left = new TreeNode(3)
                        }
                    })));
    }
}
