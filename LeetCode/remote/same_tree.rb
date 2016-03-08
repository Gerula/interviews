#   https://leetcode.com/problems/same-tree/
#    Given two binary trees, write a function to check if they are equal or not.
#
#    Two binary trees are considered equal if they are structurally identical and the nodes have the same value.
#
#
#    Submission Details
#    54 / 54 test cases passed.
#       Status: Accepted
#       Runtime: 75 ms
#           
#           Submitted: 0 minutes ago
def is_same_tree(p, q)
    return p == q if p.nil? || q.nil?
    return p.val == q.val &&
           is_same_tree(p.left, q.left) &&
           is_same_tree(p.right, q.right)
end
