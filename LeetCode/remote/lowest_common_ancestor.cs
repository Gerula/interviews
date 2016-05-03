//  https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
//   Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree. 
//   https://leetcode.com/submissions/detail/58746463/
//
//   Submission Details
//   31 / 31 test cases passed.
//      Status: Accepted
//      Runtime: 182 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q)
        {
            return root;
        }
        
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        if (left != null && right != null)
        {
            return root;
        }
        
        return left == null ? right : left;
    }

//  Same fucking thing
//  https://leetcode.com/submissions/detail/60617537/
//
//  Submission Details
//  31 / 31 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago
//  You are here!
//  Your runtime beats 97.26% of csharpsubmissions.
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null || root == p || root == q)
        {
            return root;
        }
        
        var left = LowestCommonAncestor(root.left, p, q);
        var right = LowestCommonAncestor(root.right, p, q);
        if (left != null && right != null)
        {
            return root;
        }
        
        return left == null ? right : left;
    }
}
