# https://leetcode.com/submissions/detail/36350387/

# Definition for a binary tree node.
# class TreeNode
#     attr_accessor :val, :left, :right
#     def initialize(val)
#         @val = val
#         @left, @right = nil, nil
#     end
# end

# @param {TreeNode} root
# @return {Integer[]}
def right_side_view(root)
   result = []
   side_view(root, 1, [0], result)
   return result
end

def side_view(node, level, next_level, result)
    return if node.nil?
    
    if level > next_level[0]
        result << node.val
        next_level[0] = level
    end
    
    side_view(node.right, level + 1, next_level, result)
    side_view(node.left, level + 1, next_level, result)
end
