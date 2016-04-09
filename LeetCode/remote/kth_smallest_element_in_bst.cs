//  https://leetcode.com/problems/kth-smallest-element-in-a-bst/
//
//  Celebrating > 1yr from the major clusterfuck

//  https://leetcode.com/submissions/detail/58597456/
//
//  Submission Details
//  91 / 91 test cases passed.
//      Status: Accepted
//      Runtime: 168 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        TreeNode node = null;
        Smallest(root, ref k, ref node);
        return node.val;
    }
    
    public void Smallest(TreeNode root, ref int index, ref TreeNode node)
    {
        if (root == null || node != null)
        {
            return;
        }
        
        Smallest(root.left, ref index, ref node);
        if (--index == 0)
        {
            node = root;
        }
        
        Smallest(root.right, ref index, ref node);
    }
}
