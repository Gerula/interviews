//  https://leetcode.com/problems/binary-tree-right-side-view/
//
//  Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
//
//  For example:
//  Given the following binary tree,
//
//     1            <---
//   /   \
//  2     3         <---
//   \     \
//    5     4       <---
//
//  You should return [1, 3, 4]. 

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
    //  https://leetcode.com/submissions/detail/52167191/
    //
    //
    //  Submission Details
    //  210 / 210 test cases passed.
    //      Status: Accepted
    //      Runtime: 472 ms
    //          
    //          Submitted: 0 minutes ago
    //
    //  You are here!
    //  Your runtime beats 93.02% of csharp submissions.
    public IList<int> RightSideView(TreeNode root) {
        var result = new List<int>();
        RightSide(root, 1, result);
        return result;
    }
    
    public void RightSide(TreeNode root, int level, List<int> result)
    {
        if (root == null)
        {
            return;
        }
        
        if (level > maxLevel)
        {
            maxLevel = level;
            result.Add(root.val);
        }
        
        RightSide(root.right, level + 1, result);
        RightSide(root.left, level + 1, result);
    }
}
