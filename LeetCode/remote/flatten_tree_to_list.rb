#   https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
#
#   Given a binary tree, flatten it to a linked list in-place. 
#
#   
#   Submission Details
#   225 / 225 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53079135/
#   
#   You are here!
#   Your runtime beats 100.00% of ruby submissions.

# Definition for a binary tree node.
# class TreeNode
#     attr_accessor :val, :left, :right
#     def initialize(val)
#         @val = val
#         @left, @right = nil, nil
#     end
# end

# @param {TreeNode} root
# @return {Void} Do not return anything, modify root in-place instead.
def flatten(root)
    null = TreeNode.new(-1)
    last = null
    stack = [root]
    while stack.any?
        current = stack.pop
        last.right = current
        last = last.right
        left = current.left
        right = current.right
        stack.push(right) if !right.nil?
        stack.push(left) if !left.nil?
        current.left = current.right = nil
    end
    
    null.right
end
