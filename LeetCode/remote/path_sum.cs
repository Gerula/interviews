//  https://leetcode.com/problems/path-sum/
//
//   Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum. 

//  
//  Submission Details
//  114 / 114 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago
//
//  https://leetcode.com/submissions/detail/52996618/

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
    public bool HasPathSum(TreeNode root, int sum) {
        if (root == null)
        {
            return false;
        }
        
        if (root.left == root.right && root.right == null)
        {
            return sum == root.val;
        }
        
        return HasPathSum(root.left, sum - root.val) ||
               HasPathSum(root.right, sum - root.val);
    }
}

//  lol@samefuckingthing
public class Solution {
    public bool HasPathSum(TreeNode root, int sum) {
        if (root == null)
        {
            return false;
        }
        
        if (root.left == null && root.right == null)
        {
            return sum == root.val;
        }
        
        return root.left != null && HasPathSum(root.left, sum - root.val) ||
               root.right != null && HasPathSum(root.right, sum - root.val);
    }
}
