#   https://leetcode.com/problems/balanced-binary-tree/
#   https://leetcode.com/submissions/detail/56765322/
def is_balanced(root)
    return balanced?(root) != -1
end

def balanced?(root)
    return 0 if root.nil?
    left = balanced?(root.left)
    right = balanced?(root.right)
    return -1 if left == -1 || right == -1 || (left - right).abs > 1
    return 1 + [left, right].max
end
