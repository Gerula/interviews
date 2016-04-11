//  https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
//  Given a binary search tree (BST), find the lowest common ancestor (LCA) of two given nodes in the BST. 
//  https://leetcode.com/submissions/detail/58745380/
//
//  Submission Details
//  27 / 27 test cases passed.
//      Status: Accepted
//      Runtime: 220 ms
//          
//          Submitted: 1 minute ago

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
        {
            return null;
        }
        
        if (p.val < root.val && q.val < root.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }

        if (p.val > root.val && q.val > root.val)
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        
        return root;
    }
}
