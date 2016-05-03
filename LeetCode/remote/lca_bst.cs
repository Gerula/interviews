// https://leetcode.com/submissions/detail/33874527/

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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (p.val > q.val) {
            TreeNode c = p;
            p = q;
            q = c;
        }
        
        if (root == null || p.val <= root.val && root.val <= q.val) {
            return root;
        }
        
        if (root.val > q.val) {
            return LowestCommonAncestor(root.left, p, q);
        } else {
            return LowestCommonAncestor(root.right, p, q);
        }
     }

    //  https://leetcode.com/submissions/detail/60618182/
    //
    //  Submission Details
    //  27 / 27 test cases passed.
    //      Status: Accepted
    //      Runtime: 188 ms
    //          
    //          Submitted: 0 minutes ago
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null)
        {
            return root;
        }
        
        if (Math.Max(p.val, q.val) < root.val)
        {
            return LowestCommonAncestor(root.left, p, q);
        }
        
        if (Math.Min(p.val, q.val) > root.val)
        {
            return LowestCommonAncestor(root.right, p, q);
        }
        
        return root;
    }
}
