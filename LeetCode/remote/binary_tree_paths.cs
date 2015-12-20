//  https://leetcode.com/problems/binary-tree-paths/
//
//   Given a binary tree, return all root-to-leaf paths.
//
//   For example, given the following binary tree:
//
//      1
//    /   \
//   2     3
//    \
//     5
//
//          All root-to-leaf paths are:
//
//          ["1->2->5", "1->3"]

using System;
using System.Collections.Generic;
using System.Linq;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    //  
    //  Submission Details
    //  209 / 209 test cases passed.
    //      Status: Accepted
    //      Runtime: 584 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public IList<string> BinaryTreePaths(TreeNode root) {
        if (root == null)
        {
            return new List<String>();
        }

        if (root.left == null && root.right == null)
        {
            return new List<String> { root.val.ToString() };
        }

        return BinaryTreePaths(root.left)
               .Concat(BinaryTreePaths(root.right))
               .Select(x => String.Format("{0}->{1}", root.val, x))
               .ToList();
    }

    static void Main()
    {
        var root = new TreeNode(1) {
            left = new TreeNode(2) {
                left = new TreeNode(6),
                right = new TreeNode(5)
            },
            right = new TreeNode(3) {
                left = new TreeNode(7)
            }
        };

        Console.WriteLine(String.Join(Environment.NewLine, new Solution().BinaryTreePaths(root)));
    }
}
