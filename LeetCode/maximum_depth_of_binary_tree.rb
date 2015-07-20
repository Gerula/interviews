# Maximum Depth of Binary Tree Total Accepted: 74096 Total Submissions: 164331
#
# Given a binary tree, find its maximum depth.
#
# The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
#
# wrote directly in the browser
#
# 38 / 38 test cases passed.
#   Status: Accepted
#   Runtime: 92 ms
#       
#       Submitted: 1 minute ago
#

def max_depth(root)
    return 0 if root.nil?
    max_left = root.left.nil? ? 0 : max_depth(root.left)
    max_right = root.right.nil? ? 0 : max_depth(root.right)
    return 1 + [max_left, max_right].max
end
