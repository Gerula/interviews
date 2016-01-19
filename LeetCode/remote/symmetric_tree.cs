//  https://leetcode.com/problems/symmetric-tree/
//
//  Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
//
//  For example, this binary tree is symmetric:
//

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
    public bool IsSymmetric(TreeNode root) {
        if (root == null)
        {
            return true;
        }
        
        return IsSymmetric(root.left, root.right);
    }
    
    public bool IsSymmetric(TreeNode first, TreeNode second)
    {
        if (first == null || second == null)
        {
            return first == null && second == null;
        }
        
        return first.val == second.val && IsSymmetric(first.left, second.right) && IsSymmetric(first.right, second.left);
    }
}
