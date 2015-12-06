//  https://leetcode.com/problems/unique-binary-search-trees-ii/
//
//  Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.
//

using System;
using System.Collections.Generic;
using System.Linq;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
    public override String ToString()
    {
        return String.Format(
                "{0} {1} {2}",
                val,
                left == null? "NULL" : left.ToString(),
                right == null? "NULL" : right.ToString());
    }
}

public class Solution {
    // 
    // Submission Details
    // 9 / 9 test cases passed.
    //  Status: Accepted
    //  Runtime: 448 ms
    //      
    //      Submitted: 0 minutes ago
    //
    public IList<TreeNode> GenerateTrees(int n) {
        return GenTrees(1, n);
    }

    public IList<TreeNode> GenTrees(int low, int high)
    {
        if (low == high)
        {
            return new List<TreeNode> { new TreeNode(low) };
        }

        if (low > high)
        {
            return new List<TreeNode> { null };
        }

        return Enumerable
               .Range(low, high - low + 1)
               .SelectMany(x => {
                    var nodes = new List<TreeNode>();
                    foreach (var l in GenTrees(low, x - 1))
                    {
                        foreach (var r in GenTrees(x + 1, high))
                        {
                            nodes.Add(new TreeNode(x) { left = l, right = r });
                        }
                    }

                    return nodes;
               })
               .ToList();
    }

    static void Main()
    {
        var s = new Solution();
        foreach (var tree in s.GenerateTrees(3))
        {
            Console.WriteLine(tree);
        }

        Console.WriteLine();
        foreach (var tree in s.GenerateTrees(4))
        {
            Console.WriteLine(tree);
        }
    }
}

