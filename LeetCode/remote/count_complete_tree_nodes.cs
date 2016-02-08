//  https://leetcode.com/problems/count-complete-tree-nodes/
//
//  Given a complete binary tree, count the number of nodes.
//
//  Definition of a complete binary tree from Wikipedia:
//  In a complete binary tree every level, except possibly the last,
//  is completely filled, and all nodes in the last level are as far left as possible.
//  It can have between 1 and 2h nodes inclusive at the last level h.

//  https://leetcode.com/submissions/detail/52956033/
//
//
//  Submission Details
//  18 / 18 test cases passed.
//      Status: Accepted
//      Runtime: 320 ms
//          
//          Submitted: 4 minutes ago
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
    public int CountNodes(TreeNode root) {
        var left = LeftDepth(root);
        var right = RightDepth(root);
        if (left == right)
        {
            return (1 << left) - 1;
        }
        else
        {
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
    
    public int LeftDepth(TreeNode root)
    {
        var i = 0;
        while (root != null)
        {
            i++;
            root = root.left;
        }
        
        return i;
    }
    
    public int RightDepth(TreeNode root)
    {
        var i = 0;
        while (root != null)
        {
            i++;
            root = root.right;
        }
        
        return i;
    }
}
