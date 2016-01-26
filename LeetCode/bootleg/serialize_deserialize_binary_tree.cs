//  https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
//
//  Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer,
//  or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
//
//  Design an algorithm to serialize and deserialize a binary tree.
//  There is no restriction on how your serialization/deserialization algorithm should work.
//  You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    //  
    //  https://leetcode.com/submissions/detail/51836621/
    //
    //
    //  Submission Details
    //  47 / 47 test cases passed.
    //      Status: Accepted
    //      Runtime: 232 ms
    //          
    //          Submitted: 0 minutes ago
    //

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null)
        {
            return "#";
        }
        
        return String.Format(
            "{0},{1},{2}",
            root.val,
            serialize(root.left),
            serialize(root.right));
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        var stack = new Stack<TreeNode>();
        foreach (var x in data.Split(new [] {','}).Reverse())
        {
            if (x == "#")  
            {
                stack.Push(null);
            }
            else
            {
                stack.Push(new TreeNode(int.Parse(x)) {
                    left = stack.Pop(),
                    right = stack.Pop()
                });
            }
        }
        
        return stack.Pop();
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
