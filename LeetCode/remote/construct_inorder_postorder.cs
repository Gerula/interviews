//  https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
//
//  Given inorder and postorder traversal of a tree, construct the binary tree.
//
//  Note:
//  You may assume that duplicates do not exist in the tree. 

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
//  
//  Submission Details
//  202 / 202 test cases passed.
//      Status: Accepted
//      Runtime: 940 ms HAHAHAHA Slowest ever
//          
//          Submitted: 0 minutes ago
//
//  https://leetcode.com/submissions/detail/52833603/
//
public class Solution {
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        if (!inorder.Any())
        {
            return null;
        }
        
        var index = Array.IndexOf(inorder, postorder.Last());
        return new TreeNode(postorder.Last()) {
            left = BuildTree(inorder.Take(index).ToArray(), postorder.Take(index).ToArray()),
            right = BuildTree(inorder.Skip(index + 1).ToArray(), postorder.Take(postorder.Count() - 1).Skip(index).ToArray())
        };
    }
}
