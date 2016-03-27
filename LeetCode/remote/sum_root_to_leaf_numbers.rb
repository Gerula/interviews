#   https://leetcode.com/problems/sum-root-to-leaf-numbers/
#   https://leetcode.com/submissions/detail/54734162/
#   Submission Details
#   109 / 109 test cases passed.
#       Status: Accepted
#       Runtime: 76 ms
#           
#           Submitted: 1 minute ago

#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.

def sum_numbers(root, parent = 0)
    return 0 if root.nil?
    return parent * 10 + root.val if root.left.nil? && root.right.nil?
    return sum_numbers(root.left, parent * 10 + root.val) + sum_numbers(root.right, parent * 10 + root.val)
end

# LoL @ Coding olympics
# Exact same fucking thing
# https://leetcode.com/submissions/detail/57444479/
#
# Submission Details
# 109 / 109 test cases passed.
#   Status: Accepted
#   Runtime: 88 ms
#       
#       Submitted: 0 minutes ago
# You are here!
# Your runtime beats 100.00% of rubysubmissions.
def sum_numbers(root, parent = 0)
    return 0 if root.nil?
    return parent * 10 + root.val if root.left.nil? && root.right.nil?
    return sum_numbers(root.left, parent * 10 + root.val) + sum_numbers(root.right, parent * 10 + root.val)
end
