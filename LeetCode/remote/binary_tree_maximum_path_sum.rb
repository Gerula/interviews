#   https://leetcode.com/problems/binary-tree-maximum-path-sum/
#    Given a binary tree, find the maximum path sum.
#
#    For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree along the parent-child connections.
#    The path does not need to go through the root.
#   https://leetcode.com/submissions/detail/54607834/
#
#   Submission Details
#   92 / 92 test cases passed.
#       Status: Accepted
#       Runtime: 180 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions. Yeah baby!

def max_path_sum(root)
    max_val = [-2 ** (0.size * 8 - 2)]
    max(root, max_val)
    max_val[0]
end

def max(root, max)
    return 0 if root.nil?
    left = max(root.left, max)
    right = max(root.right, max)
    current_include = [[left, right].max + root.val, root.val].max
    max[0] = [max[0], 
              current_include,
              left + right + root.val].max
    return current_include
end
