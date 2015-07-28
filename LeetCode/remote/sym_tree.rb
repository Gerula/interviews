# https://leetcode.com/submissions/detail/34414891/

# Definition for a binary tree node.
# class TreeNode
#     attr_accessor :val, :left, :right
#     def initialize(val)
#         @val = val
#         @left, @right = nil, nil
#     end
# end

# @param {TreeNode} root
# @return {Boolean}

class TreeNode
    def left_side
        return "#{@val} #{left.nil? ? "." : @left.left_side} #{right.nil? ? "." : @right.left_side}"
    end
    
    def right_side
        return "#{@val} #{right.nil? ? "." : @right.right_side} #{left.nil? ? "." : @left.right_side}"
    end
end

def is_symmetric(root)
    return true if root.nil?
    return root.left_side == root.right_side
end
