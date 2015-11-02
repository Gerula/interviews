// https://leetcode.com/problems/unique-binary-search-trees-ii/
//
// Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.
//
// For example,
// Given n = 3, your program should return all 5 unique BST's shown below.
//
//    1         3     3      2      1
//     \       /     /      / \      \
//      3     2     1      1   3      2
//     /     /       \                 \
//    2     1         2                 3
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
                "{0} {1} {2} ",
                val,
                left == null ? "NULL" : left.ToString(),
                right == null ? "NULL" : right.ToString());
    }
}

public class Solution {
    public static IList<TreeNode> GenerateTrees(int n) {
        return Generate(1, n);
    }

    public static IList<TreeNode> Generate(int start, int n)
    {
        List<TreeNode> result = new List<TreeNode>();
        if (start > n)
        {
            result.Add(null);
            return result;
        }

        for (int i = start; i <= n ; i++)
        {
            IList<TreeNode> Left = Generate(start, i - 1);
            IList<TreeNode> Right = Generate(i + 1, n);

            result.AddRange(Left.SelectMany(x => Right.Select(y => new TreeNode(i) {
                                left = x,
                                right = y
                            })));
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine(String.Join(Environment.NewLine, GenerateTrees(3)));
    }
}
