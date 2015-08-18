// https://leetcode.com/submissions/detail/36703260/

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
        List<int> numbers = new List<int>();
        SumLeaves(root, 0, numbers);
        return numbers.Sum();
    }
    
    public void SumLeaves(TreeNode node, int number, List<int> numbers) {
        if (node == null) {
            return;
        }
        
        int current = number * 10 + node.val;
        if (node.left == null && node.right == null) {
            numbers.Add(current);
            return;
        }
        
        SumLeaves(node.left, current, numbers);
        SumLeaves(node.right, current, numbers);
    }
}
