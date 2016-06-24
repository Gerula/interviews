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

    //  https://leetcode.com/submissions/detail/65154004/
    //
    //  Submission Details
    //  34 / 34 test cases passed.
    //      Status: Accepted
    //      Runtime: 544 ms
    //          
    //          Submitted: 1 minute ago
    public IList<IList<int>> LevelOrder(TreeNode root) {
        if (root == null) {
            return new List<IList<int>>();
        }
        
        var left = LevelOrder(root.left);
        var right = LevelOrder(root.right);
        return new List<IList<int>> { new [] { root.val }.ToList() }
               .Concat(left.Zip(right, (x, y) => x.Concat(y).ToList()))
               .Concat(left.Skip(right.Count()))
               .Concat(right.Skip(left.Count()))
               .ToList<IList<int>>();
    }
}
