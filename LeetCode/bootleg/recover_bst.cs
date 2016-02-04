//  https://leetcode.com/problems/recover-binary-search-tree/
//
//   Two elements of a binary search tree (BST) are swapped by mistake.
//
//   Recover the tree without changing its structure. 

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
    //  
    //  Submission Details
    //      Status: Accepted
    //      Runtime: 248 ms
    //          
    //          Submitted: 3 months ago
    //
    //  https://leetcode.com/submissions/detail/44700357/
    //
    public void RecoverTree(TreeNode root) {
        var stack = new Stack<TreeNode>();
        var current = root;
        TreeNode prev = null;
        TreeNode next = null;
        TreeNode first = null;
        TreeNode second = null;
        while (stack.Count > 0 || current != null)
        {
            if (current == null)
            {
                current = stack.Pop();
                if (prev != null && current.val < prev.val)
                {
                    if (first == null)
                    {
                        first = prev;
                        next = current;
                    }
                    else
                    {
                        second = current;
                    }
                }
                prev = current;
                current = current.right;
            }
            else
            {
                stack.Push(current);
                current = current.left;
            }
        }
        
        if (second == null)
        {
            Swap(ref first.val, ref next.val);
        }
        else
        {
            Swap(ref first.val, ref second.val);
        }
    }
    
    static void Swap(ref int a, ref int b)
    {
        var c = a;
        a = b;
        b = c;
    }
}

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
    //  https://leetcode.com/submissions/detail/52672449/ 
    //
    //
    //  Submission Details
    //  1916 / 1916 test cases passed.
    //      Status: Accepted
    //      Runtime: 268 ms
    //          
    //          Submitted: 0 minutes ago
    //
    public void RecoverTree(TreeNode root) {
        var pre = new TreeNode(int.MinValue);
        TreeNode first = null;
        TreeNode second = null;
        Recover(root, ref pre, ref first, ref second);
        if (first != null && second != null)
        {
            Swap(ref first.val, ref second.val);
        }
    }
    
    public void Recover(TreeNode root, ref TreeNode pre, ref TreeNode first, ref TreeNode second)
    {
        if (root == null)
        {
            return;
        }
        
        Recover(root.left, ref pre, ref first, ref second);
        if (root.val < pre.val)
        {
            if (first == null)
            {
                first = pre;
            }
            
            second = root;
        }
        
        pre = root;
        Recover(root.right, ref pre, ref first, ref second);
    }
    
    static void Swap(ref int a, ref int b)
    {
        var c = a;
        a = b;
        b = c;
    }
}
