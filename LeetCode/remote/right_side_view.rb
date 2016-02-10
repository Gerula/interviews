#   https://leetcode.com/problems/binary-tree-right-side-view/
#
#   Given a binary tree, imagine yourself standing on the right side of it,
#   return the values of the nodes you can see ordered from top to bottom.
#
#
#   Submission Details
#   210 / 210 test cases passed.
#       Status: Accepted
#       Runtime: 88 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53124533/

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
    right_side(root, 1, [0]) 
end

def right_side(root, current_level, level)
    result = []
    return result if root.nil?
    if current_level > level[0]
        level[0] = current_level
        result << root.val
    end
    
    return result + right_side(root.right, current_level + 1, level) + right_side(root.left, current_level + 1, level)
end
