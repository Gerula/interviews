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

//  https://leetcode.com/submissions/detail/65861224/
//
//  Submission Details
//  225 / 225 test cases passed.
//      Status: Accepted
//      Runtime: 164 ms
//          
//          Submitted: 0 minutes ago
public class Solution {
    public void Flatten(TreeNode root) {
        if (root == null) {
            return;
        }
        
        var prev = new TreeNode(-1);
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Any()) {
            var current = stack.Pop();
            if (current.right != null) {
                stack.Push(current.right);
            }
            
            if (current.left != null) {
                stack.Push(current.left);
                current.left = null;
            }
            
            prev.right = current;
            prev = prev.right;
        }
    }
}
