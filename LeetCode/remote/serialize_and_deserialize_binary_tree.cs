//  https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
//  Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer,
//  or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
//
//  Design an algorithm to serialize and deserialize a binary tree.
//  There is no restriction on how your serialization/deserialization algorithm should work.
//  You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.

//  https://leetcode.com/submissions/detail/65302917/
//
//  Submission Details
//  47 / 47 test cases passed.
//      Status: Accepted
//      Runtime: 244 ms
//          
//          Submitted: 0 minutes ago
public class Codec {
    // 1 2 null null 3 4 null null 5 null null
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) {
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
        return data.Split(
            new [] {','},
            StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .Aggregate(
                 new Stack<TreeNode>(),
                 (acc, x) => {
                     if (x == "#") {
                         acc.Push(null);
                     } else {
                         acc.Push(new TreeNode(int.Parse(x)) {
                             left = acc.Pop(),
                             right = acc.Pop()
                         });
                     }
                     
                     return acc;
                 }).Pop();
    }

    // Recursive descent parser - TLE - probably from all the string replacements..
    // (1(2)(3(4)(5)))
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if (root == null) {
            return "()";
        }
        
        return String.Format(
            "({0}{1}{2})",
            root.val,
            serialize(root.left),
            serialize(root.right));
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        return deserialize(ref data);
    }

    public TreeNode deserialize(ref string data) {
        if (String.IsNullOrWhiteSpace(data))
        {
            return null;
        }
        
        if (data.StartsWith("()"))
        {
            data = data.Substring(2);
            return null;
        }
        
        var i = 1;
        while (i++ < data.Length && data[i] != '(') {}
        var val = int.Parse(data.Substring(1, i - 1));
        data = data.Substring(i);
        var result = new TreeNode(val) {
            left = deserialize(ref data),
            right = deserialize(ref data)
        };
        
        data = data.Substring(1);
        return result;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));
