//  https://leetcode.com/problems/binary-tree-level-order-traversal/
//  https://leetcode.com/submissions/detail/59043589/
//
//  Submission Details
//  34 / 34 test cases passed.
//      Status: Accepted
//      Runtime: 648 ms
//          
//          Submitted: 0 minutes ago

public class Solution {
    public IList<IList<int>> LevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if (root == null)
        {
            return result;
        }
    
        result.Add(new List<int> { root.val });
        var left = LevelOrder(root.left);
        var right = LevelOrder(root.right);
        for (var i = 0; i < Math.Max(left.Count, right.Count); i++)
        {
           var level = new List<int>();
           if (i < left.Count)
           {
               level.AddRange(left[i]);
           }
    
            if (i < right.Count)
            {
                level.AddRange(right[i]);
            }
            
            result.Add(level);
        }
    
        return result;        
    }
}
