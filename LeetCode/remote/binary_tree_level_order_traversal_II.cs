//  https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
//  Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).
//
//  https://leetcode.com/submissions/detail/60352465/
//
//  Submission Details
//  34 / 34 test cases passed.
//      Status: Accepted
//      Runtime: 680 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }
        
        var left = LevelOrderBottom(root.left);
        var right = LevelOrderBottom(root.right);
        var i = left.Count;
        var j = right.Count;
        while (i > 0 || j > 0)
        {
            result.Add(
                (i > 0 ? left[--i] : new List<int>())
                .Concat(j > 0 ? right[--j] : new List<int>())
                .ToList());
        }

        result.Reverse();
        result.Add(new List<int> { root.val });
        return result;
    }
}
