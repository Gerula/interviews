//  https://leetcode.com/problems/unique-binary-search-trees-ii/
//
//  Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.
//

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
    //  Now with cache (poor man's DP)
    //
    //
    //  Submission Details
    //  9 / 9 test cases passed.
    //      Status: Accepted
    //      Runtime: 396 ms (as opposed to 476 with no cache)
    //          
    //          Submitted: 0 minutes ago
    //
    //          You are here!
    //          Your runtime beats 76.00% of csharp submissions.
    //
    //  https://leetcode.com/submissions/detail/52384209/
    //
    public IList<TreeNode> GenerateTrees(int n) {
        if (n == 0)
        {
            return new List<TreeNode>();
        }
        var cache = new Dictionary<String, List<TreeNode>>();
        return GenerateTrees(1, n, cache);
    }
    
    public IList<TreeNode> GenerateTrees(int low, int high, Dictionary<String, List<TreeNode>> cache) {
        var key = String.Format("{0}.{1}", low, high);
        if (cache.ContainsKey(key))
        {
            return cache[key];
        }
        
        if (low > high)
        {
            cache[key] = new List<TreeNode> { null };
            return cache[key];
        }
        
        var result = new List<TreeNode>();
        for (var i = low; i <= high; i++)
        {
            foreach (var l in GenerateTrees(low, i - 1, cache))
            {
                foreach (var r in GenerateTrees(i + 1, high, cache))
                {
                    result.Add(new TreeNode(i) { left = l, right = r});
                }
            }
        }
        
        cache[key] = result;
        return cache[key];
    }
}
