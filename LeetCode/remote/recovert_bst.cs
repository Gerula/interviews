// https://leetcode.com/problems/recover-binary-search-tree/
//
//  Two elements of a binary search tree (BST) are swapped by mistake.
//
//  Recover the tree without changing its structure. 
//
// 
// Submission Details
// 1916 / 1916 test cases passed.
//  Status: Accepted
//  Runtime: 248 ms
//      
//      Submitted: 0 minutes ago
//  
//  https://leetcode.com/submissions/detail/44700357/


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
                "{0} {1}{2}",
                left == null? String.Empty : left.ToString(),
                val,
                right == null? String.Empty : right.ToString());
    }
}

class Program
{
    public static void RecoverTree(TreeNode root) {
        var stack = new Stack<TreeNode>();
        var current = root;
        TreeNode first = null;
        TreeNode prev = null;
        TreeNode next = null;
        TreeNode second = null;
        
        while (stack.Count != 0 || current != null)
        {
            if (current != null)
            {
                stack.Push(current);
                current = current.left;
            }
            else
            {
                current = stack.Pop();
                if (prev != null && current.val < prev.val)
                {
                    if (first == null)
                    {
                        first = prev;
                        next = current;
                    }
                    else
                    {
                        second = current;
                    }
                }
                prev = current;
                current = current.right;
            }
        }

        if (second != null)
        {
            Swap(ref first.val, ref second.val);
        }
        else
        {
            Swap(ref first.val, ref next.val);
        }
    }

    static void Swap(ref int a, ref int b)
    {
        var c = a;
        a = b;
        b = c;
    }

    public static void Main()
    {
        new [] { 
            new TreeNode(5) {
                left = new TreeNode(3) {
                    right = new TreeNode(4),
                    left = new TreeNode(2)
                },
                right = new TreeNode(8) {
                    right = new TreeNode(7),
                    left = new TreeNode(6)
                }
            },
            new TreeNode(5) {
                left = new TreeNode(3) {
                    right = new TreeNode(4),
                    left = new TreeNode(8)
                },
                right = new TreeNode(7) {
                    right = new TreeNode(2),
                    left = new TreeNode(6)
                }
            }
        }.
        ToList().
        ForEach(x => {
            Console.WriteLine("Before {0}", x);
            RecoverTree(x);
            Console.WriteLine("After {0}", x);
            Console.WriteLine();
        });
    }
}
