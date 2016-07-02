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

//  Better than the previous as it can lead to the O(log n) solution. Granted it's slower but again,
//  in repeating queries, we can hash the count values and then lead the the good solution.
//  Fuck coding interviews.
//
//
//  Submission Details
//  91 / 91 test cases passed.
//      Status: Accepted
//      Runtime: 192 ms
//          
//          Submitted: 1 hour, 5 minutes ago
//  https://leetcode.com/submissions/detail/65952474/

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        if (root == null) {
            return 0;
        }
        
        var leftCount = CountNodes(root.left);
        
        if (leftCount + 1 == k) {
            return root.val;
        }
        
        if (leftCount >= k) {
            return KthSmallest(root.left, k);
        }
        
        return KthSmallest(root.right, k - leftCount - 1);
    }
    
    private int CountNodes(TreeNode root) {
        if (root == null) {
            return 0;
        }
        
        return 1 + CountNodes(root.left) + CountNodes(root.right);
    }
}
