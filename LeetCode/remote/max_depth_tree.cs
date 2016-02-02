//  https://leetcode.com/problems/maximum-depth-of-binary-tree/
//
//  Given a binary tree, find its maximum depth.
//
//  The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    //  
    //  Submission Details
    //  38 / 38 test cases passed.
    //      Status: Accepted
    //      Runtime: 184 ms
    //          
    //          Submitted: 2 minutes ago
    //
    //  https://leetcode.com/submissions/detail/52481430/
    //
    public int MaxDepth(TreeNode root) {
        return root == null? 0 : 1 + Math.Max(MaxDepth(root.right), MaxDepth(root.left));
    }
}
