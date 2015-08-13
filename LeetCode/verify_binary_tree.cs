// https://leetcode.com/submissions/detail/36145656/

public class Solution {
    public bool IsValidBST(TreeNode root) {
        return IsValid(root, Int64.MinValue, Int64.MaxValue);
    }
    
    public bool IsValid(TreeNode root, Int64 min, Int64 max) {
        if (root == null) {
            return true;
        }
        
        return (min < root.val && 
                root.val < max && 
                IsValid(root.left, min, root.val) &&
                IsValid(root.right, root.val, max));
    }
}
