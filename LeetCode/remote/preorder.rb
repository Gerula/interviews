#   https://leetcode.com/problems/binary-tree-preorder-traversal/
#
#   Given a binary tree, return the preorder traversal of its nodes' values.

#   https://leetcode.com/submissions/detail/53374225/
#
#
#   Submission Details
#   67 / 67 test cases passed.
#       Status: Accepted
#       Runtime: 56 ms
#           
#           Submitted: 0 minutes ago
#
#   You are here!
#   Your runtime beats 100.00% of ruby submissions.

def preorder_traversal(root)
    stack = [root]
    result = []
    while stack.any?
        result << stack.pop
        stack.push(result[-1].right) if !result[-1].right.nil?
        stack.push(result[-1].left) if !result[-1].left.nil?
    end
    
    result.map { |x| x.val }
end
