#   https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
#   Serialization is the process of converting a data structure or object into a sequence of bits so that it can be stored in a file or memory buffer,
#   or transmitted across a network connection link to be reconstructed later in the same or another computer environment.
#
#   Design an algorithm to serialize and deserialize a binary tree.
#   There is no restriction on how your serialization/deserialization algorithm should work.
#   You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized to the original tree structure.
#   https://leetcode.com/submissions/detail/55422904/
#
#   Submission Details
#   47 / 47 test cases passed.
#       Status: Accepted
#       Runtime: 480 ms
#           
#           Submitted: 0 minutes ago
# Encodes a tree to a single string.
#
# @param {TreeNode} root
# @return {string}
def serialize(root)
    return "null" if root.nil?
    return "#{root.val},#{serialize(root.left)},#{serialize(root.right)}"
end

# Decodes your encoded data to tree.
#
# @param {string} data
# @return {TreeNode}
def deserialize(data)
    stack = []
    data.split(",").reverse.each { |node|
        if node == "null"
            stack << nil
        else
            new = TreeNode.new(node.to_i)
            new.left = stack.pop
            new.right = stack.pop
            stack << new
        end
    }
    
    stack.first
end

