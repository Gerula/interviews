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

#   https://leetcode.com/submissions/detail/55657432/
#
#   Submission Details
#   54 / 54 test cases passed.
#       Status: Accepted
#       Runtime: 72 ms
#           
#           Submitted: 0 minutes ago
class TreeNode
    def hash
        "#{self.val},#{self.left.nil? ? "." : self.left.hash},#{self.right.nil? ? "." : self.right.hash}"
    end
end

def is_same_tree(p, q)
    return p.hash == q.hash
end
