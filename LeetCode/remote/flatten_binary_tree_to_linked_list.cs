//  https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
//   Given a binary tree, flatten it to a linked list in-place. 
//   https://leetcode.com/submissions/detail/60432907/
//
//   Submission Details
//   225 / 225 test cases passed.
//      Status: Accepted
//      Runtime: 164 ms
//          
//          Submitted: 0 minutes ago
//

public class Solution {
    public void Flatten(TreeNode root) {
        root = FlattenTree(root);
    }
    
    TreeNode FlattenTree(TreeNode root) {
        if (root == null)
        {
            return root;
        }
        
        var left = root.left;
        var right = root.right;
        root.left = null;
        root.right = null;
        left = FlattenTree(left);
        right = FlattenTree(right);
        root.right = left;
        var it = root;
        while (it != null && it.right != null)
        {
            it = it.right;
        }
        
        it.right = right;
        return root;
    }
}
