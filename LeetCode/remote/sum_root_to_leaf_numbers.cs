//  https://leetcode.com/problems/sum-root-to-leaf-numbers/
//
//  Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.
//
//  An example is the root-to-leaf path 1->2->3 which represents the number 123.
//
//  Find the total sum of all root-to-leaf numbers.

//  https://leetcode.com/submissions/detail/52957532/
//
//
//  Submission Details
//  109 / 109 test cases passed.
//      Status: Accepted
//      Runtime: 184 ms
//          
//          Submitted: 0 minutes ago
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
    public int SumNumbers(TreeNode root) {
        if (root == null)
        {
            return 0;
        }
        
        return SumNumbers(root, 0).Sum();
    }
    
    public IEnumerable<int> SumNumbers(TreeNode root, int parent)
    {
        if (root == null)
        {
            return Enumerable.Empty<int>();
        }
        
        if (root.left == null && root.right == null)
        {
            return new List<int> { parent * 10 + root.val };
        }
        
        return SumNumbers(root.left, parent * 10 + root.val)
               .Concat(SumNumbers(root.right, parent * 10 + root.val));
    }
}

//  https://leetcode.com/submissions/detail/60822399/
//
//  Submission Details
//  109 / 109 test cases passed.
//      Status: Accepted
//      Runtime: 170 ms
//          
//          Submitted: 0 minutes ago
//
public class Solution {
    public int SumNumbers(TreeNode root, int parent = 0) {
        if (root == null)
        {
            return 0;
        }
        
        var current = parent + root.val;
        if (root.left == null && root.right == null)
        {
            return current;
        }
        
        return SumNumbers(root.left, current * 10) +
               SumNumbers(root.right, current * 10);
    }
}
