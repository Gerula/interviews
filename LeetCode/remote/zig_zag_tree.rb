#   https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
#
#   Given a binary tree, return the zigzag level order traversal of its nodes' values.
#   (ie, from left to right, then right to left for the next level and alternate between).

#   https://leetcode.com/submissions/detail/53673579/
#   Submission Details
#   33 / 33 test cases passed.
#       Status: Accepted
#       Runtime: 68 ms
#           
#           Submitted: 0 minutes ago
#
#   You are here!
#   Your runtime beats 88.89% of rubysubmissions.

# @param {TreeNode} root
# @return {Integer[][]}
def zigzag_level_order(root)
    return zig_zag(root, 0) || []
end

def zig_zag(node, level, result = nil)
    return result if node.nil?
    result ||= []
    result[level] ||= []
    if level % 2 == 0
        result[level] << node.val
    else
        result[level].unshift(node.val)
    end
    
    result = zig_zag(node.left, level + 1, result)
    result = zig_zag(node.right, level + 1, result)
    return result
end
