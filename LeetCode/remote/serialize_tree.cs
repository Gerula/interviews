// https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
//
// Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer, or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
//
// Design an algorithm to serialize and deserialize a binary tree. There is no restriction on how your serialization/deserialization algorithm should work. You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.
//
//
// 
// Submission Details
// 47 / 47 test cases passed.
//  Status: Accepted
//  Runtime: 232 ms
//      
//      Submitted: 0 minutes ago
//
//      https://leetcode.com/submissions/detail/44159195/

using System;
using System.Collections.Generic;

public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
     public override String ToString()
     {
         return String.Format("{0} {1} {2}",
                 val,
                 left == null ? "NULL" : left.ToString(),
                 right == null ? "NULL" : right.ToString());
     }
}

public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        List<String> result = new List<String>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count != 0)
        {
            TreeNode current = stack.Pop();
            if (current == null)
            {
                result.Add("NULL");
                continue;
            }
            else
            {
                result.Add(current.val.ToString());
            }
            
            stack.Push(current.right);
            stack.Push(current.left);
        }

        return String.Join(" ", result);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        var nodes = data.Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);
        var stack = new Stack<TreeNode>();
        for (int i = nodes.Length - 1; i >= 0; i--)
        {
            if (nodes[i] == "NULL")
            {
                stack.Push(null);
            }
            else
            {
                stack.Push(new TreeNode(int.Parse(nodes[i])) {
                                    left = stack.Pop(),
                                    right = stack.Pop()
                                });
            }
        }

        return stack.Pop();
    }
}

class Program 
{
    static bool TreeEqual(TreeNode first, TreeNode second)
    {
        if (first == null || second == null)
        {
            return first == second;
        }

        return first.val == second.val &&
               TreeEqual(first.left, second.left) &&
               TreeEqual(first.right, second.right);
    }

    static TreeNode Generate(int low, int high)
    {
        if (low > high)
        {
            return null;
        }

        int mid = low + (high - low) / 2;
        return new TreeNode(mid) { 
            left = Generate(low, mid - 1),
            right = Generate(mid + 1, high)
        };
    }

    static void Main()
    {
        TreeNode root = Generate(1, 20);
        Codec codec = new Codec();
        if (!TreeEqual(root, codec.deserialize(codec.serialize(root)))) 
        {
            throw new Exception("Yousuck!" + codec.serialize(root));
        }

        Console.WriteLine("All appears to be well");
    }
}
