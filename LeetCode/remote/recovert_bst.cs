// https://leetcode.com/problems/recover-binary-search-tree/
//
//  Two elements of a binary search tree (BST) are swapped by mistake.
//
//  Recover the tree without changing its structure. 
//

using System;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }

    public override String ToString()
    {
        return String.Format(
                "{0} {1}{2}",
                left == null? String.Empty : left.ToString(),
                val,
                right == null? String.Empty : right.ToString());
    }
}

class Program
{
    public static void RecoverTree(TreeNode root) {
    }

    public static void Main()
    {
        var tree = new TreeNode(5) {
            left = new TreeNode(3) {
                right = new TreeNode(4),
                left = new TreeNode(2)
            },
            right = new TreeNode(8) {
                right = new TreeNode(7),
                left = new TreeNode(6)
            }
        };

        Console.WriteLine("Before {0}", tree);
        RecoverTree(tree);
        Console.WriteLine("After {0}", tree);
    }
}
