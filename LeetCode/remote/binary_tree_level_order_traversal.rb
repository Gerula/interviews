#   https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
#   Given a binary tree, return the zigzag level order traversal of its nodes' values.
#   (ie, from left to right, then right to left for the next level and alternate between).
#   https://leetcode.com/submissions/detail/56864436/
#
#   Submission Details
#   33 / 33 test cases passed.
#       Status: Accepted
#       Runtime: 92 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 0.00% of rubysubmissions.
def zigzag_level_order(root, hash = nil, level = 0)
    hash ||= []
    return hash if root.nil?
    hash[level] ||= []
    if level & 1 == 0
        hash[level].push(root.val)
    else
        hash[level].unshift(root.val)
    end
    
    zigzag_level_order(root.left, hash, level + 1) if root.left
    zigzag_level_order(root.right, hash, level + 1) if root.right
    hash
end
