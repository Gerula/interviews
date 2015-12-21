//  https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
//
//  Given preorder and inorder traversal of a tree, construct the binary tree.


using System;
using System.Collections.Generic;
using System.Linq;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }

    public override String ToString()
    {
        return String.Format(
                "{0} {1}{2}",
                val,
                left == null ? "." : left.ToString(),
                right == null ? "." : right.ToString());
    }

    public static TreeNode Generate(int low, int high)
    {
        if (low > high)
        {
            return null;
        }

        var mid = low + (high - low) / 2;
        return new TreeNode(mid) {
            left = Generate(low, mid - 1),
            right = Generate(mid + 1, high)
        };
    }

    public int[] Inorder()
    {
        return this
               .In()
               .Select(x => x.val)
               .ToArray();
    }

    public int[] Preorder()
    {
        return this
               .Pre()
               .Select(x => x.val)
               .ToArray();
    }

    private IEnumerable<TreeNode> Pre()
    {
        yield return this;

        if (this.left != null)
        {
            foreach (var n in this.left.Pre())
            {
                yield return n;
            }
        }

        if (this.right != null)
        {
            foreach (var n in this.right.Pre())
            {
                yield return n;
            }
        }
    }

    private IEnumerable<TreeNode> In()
    {
        if (this.left != null)
        {
            foreach (var n in this.left.In())
            {
                yield return n;
            }
        }

        yield return this;

        if (this.right != null)
        {
            foreach (var n in this.right.In())
            {
                yield return n;
            }
        }
    }
}

public class Solution {
    //  
    //  Submission Details
    //  202 / 202 test cases passed.
    //      Status: Accepted
    //      Runtime: 936 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //          HAHA Slowest solution because of all the enumerations
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        if (!preorder.Any())
        {
            return null;
        }

        var current = preorder.First();
        var index = Array.IndexOf(inorder, current);
        return new TreeNode(preorder.First()) {
            left = BuildTree(preorder.Skip(1).Take(index).ToArray(), inorder.Take(index).ToArray()),
            right = BuildTree(preorder.Skip(index + 1).ToArray(), inorder.Skip(index + 1).ToArray())
        };
    }

    static void Main()
    {
        var root = TreeNode.Generate(1, 25);
        var pre = root.Preorder().ToArray();
        var ino = root.Inorder().ToArray();
        Console.WriteLine(String.Join(", ", ino));
        Console.WriteLine(String.Join(", ", pre));

        var newRoot = new Solution().BuildTree(pre, ino);
        Console.WriteLine(String.Join(", ", newRoot.Inorder()));
        Console.WriteLine(String.Join(", ", newRoot.Preorder()));
    }
}
