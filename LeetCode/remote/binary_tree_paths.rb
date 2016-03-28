#   https://leetcode.com/problems/binary-tree-paths/
#   https://leetcode.com/submissions/detail/54646178/

def binary_tree_paths(root)
    return [] if root.to_s.empty?
    return ["#{root.val}"] if root.left.nil? && root.right.nil?
    (binary_tree_paths(root.left) + binary_tree_paths(root.right))
    .map { |x|
        "#{root.val}->#{x}"
    }
end

#   https://leetcode.com/submissions/detail/57522804/
#
#   Submission Details
#   209 / 209 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
#
def binary_tree_paths(root)
    return [] if root.nil?
    return [root.val.to_s] if root.left.nil? && root.right.nil?
    (binary_tree_paths(root.left) +
    binary_tree_paths(root.right)).map { |x|
        "#{root.val}->#{x}"
    }
end
