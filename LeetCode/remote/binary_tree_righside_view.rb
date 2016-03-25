#   https://leetcode.com/problems/binary-tree-right-side-view/
#   Given a binary tree, imagine yourself standing on the right side of it,
#   return the values of the nodes you can see ordered from top to bottom.
#   https://leetcode.com/submissions/detail/57224971/
#
#   Submission Details
#   210 / 210 test cases passed.
#       Status: Accepted
#       Runtime: 100 ms
#           
#           Submitted: 0 minutes ago
def right_side_view(root, max_level = [-1], current_level = 0)
    return [] if root.nil?
    result = []
    if max_level[0] < current_level
        result = [root.val]
        max_level[0] = current_level
    end
    
    return result +
           right_side_view(root.right, max_level, current_level + 1) +
           right_side_view(root.left, max_level, current_level + 1)
end
