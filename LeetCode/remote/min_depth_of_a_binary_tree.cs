//  https://leetcode.com/problems/minimum-depth-of-binary-tree/
//  Given a binary tree, find its minimum depth.
//
//  The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.
//  https://leetcode.com/submissions/detail/60538447/
//
//  Submission Details
//  41 / 41 test cases passed.
//      Status: Accepted
//      Runtime: 200 ms
//          
//          Submitted: 1 minute ago
public class Solution {
    public int MinDepth(TreeNode root) {
        if (root == null)
        {
            return 0;
        }
        
        if (root.left == null && root.right == null)
        {
            return 1;
        }
        
        return 1 + Math.Min(
            root.left == null ? int.MaxValue : MinDepth(root.left),
            root.right == null ? int.MaxValue : MinDepth(root.right));
    }
}
