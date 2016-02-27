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
