# https://leetcode.com/submissions/detail/34276878/

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
def is_symmetric(root)
    return true if root.nil?
    return check(root.left, root.right)
end

def check(left, right)
    if left.nil? || right.nil?
        return left.nil? && right.nil?
    end
    
    return left.val == right.val &&
           check(left.right, right.left) &&
           check(left.left, right.right)
end
