# https://leetcode.com/submissions/detail/34211484/

# Definition for a binary tree node.
# class TreeNode
#     attr_accessor :val, :left, :right
#     def initialize(val)
#         @val = val
#         @left, @right = nil, nil
#     end
# end

# @param {TreeNode} root
# @return {Integer[][]}
def level_order(root)
    result = []
    level(root, result, 0)
    return result
end

def level(node, result, level)
    return if node.nil?
    
    result[level] ||= []
    result[level] << node.val
    
    level(node.left, result, level + 1)
    level(node.right, result, level + 1)
end

