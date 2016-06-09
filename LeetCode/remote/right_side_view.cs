//  https://leetcode.com/problems/binary-tree-right-side-view/
//  Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
//  https://leetcode.com/submissions/detail/63827291/
//
//  Submission Details
//  210 / 210 test cases passed.
//      Status: Accepted
//      Runtime: 512 ms
//          
//          Submitted: 0 minutes ago
//  Functional!

public class Solution {
    public IList<int> RightSideView(TreeNode root) {
        if (root == null) {
            return new List<int>();
        }
        
        var right = RightSideView(root.right);
        var left = RightSideView(root.left);
        return new [] { root.val }
               .Concat(right.Concat(left.Skip(right.Count))).ToList();
    }
}
