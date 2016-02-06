//  https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
//
//  Given a binary tree, return the zigzag level order traversal of its nodes' values.
//  (ie, from left to right, then right to left for the next level and alternate between).

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
//  
//  Submission Details
//  33 / 33 test cases passed.
//      Status: Accepted
//      Runtime: 516 ms
//          
//          Submitted: 1 minute ago
//
//  https://leetcode.com/submissions/detail/52797190/
// Saved 40ms by storing the last level and not sorting the dictionary
//
public class Solution {
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var result = new Dictionary<int, LinkedList<int>>();
        var maxLevel = 0;
        Traverse(root, 0, result, ref maxLevel);
        return Enumerable
               .Range(1, maxLevel)
               .Select(x => (IList<int>)
                            result[x]
                            .ToList())
               .ToList();
    }
    
    public void Traverse(TreeNode root, int level, Dictionary<int, LinkedList<int>> nodes, ref int maxLevel)
    {
        if (root == null)
        {
            return;
        }
        
        level++;
        maxLevel = Math.Max(level, maxLevel);
        if (!nodes.ContainsKey(level))
        {
            nodes[level] = new LinkedList<int>();    
        }
        
        if (level % 2 == 1)
        {
            nodes[level].AddLast(root.val);
        }
        else
        {
            nodes[level].AddFirst(root.val);
        }
        
        Traverse(root.left, level, nodes, ref maxLevel);
        Traverse(root.right, level, nodes, ref maxLevel);
    }

}
