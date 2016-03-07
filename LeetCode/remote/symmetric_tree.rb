#   https://leetcode.com/problems/symmetric-tree/
#   Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
#   https://leetcode.com/submissions/detail/55551974/
#
#   Submission Details
#   192 / 192 test cases passed.
#       Status: Accepted
#       Runtime: 100 ms
#           
#           Submitted: 0 minutes ago
def is_symmetric(root)
    root.nil? ? true : symmetric(root.left, root.right)
end

def symmetric(first, second)
    return first.nil? && second.nil? if first.nil? || second.nil? 
    return first.val == second.val &&
           symmetric(first.left, second.right) &&
           symmetric(first.right, second.left)
end
