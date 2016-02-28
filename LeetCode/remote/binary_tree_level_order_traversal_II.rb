#   https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
#   Given a binary tree, return the bottom-up level order traversal of its nodes' values.
#   (ie, from left to right, level by level from leaf to root).
#
#   https://leetcode.com/submissions/detail/54734518/
#
#   Submission Details
#   34 / 34 test cases passed.
#       Status: Accepted
#       Runtime: 78 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.

def level_order_bottom(root)
    result = []    
    level_order(root, result, 0)
    result.reverse
end

def level_order(root, result, level)
    return if root.nil?
    result[level] ||= []
    result[level] << root.val
    level_order(root.left, result, level + 1)
    level_order(root.right, result, level + 1)
end
