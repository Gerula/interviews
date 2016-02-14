#   https://leetcode.com/problems/largest-number/
#
#   Given a list of non negative integers, arrange them such that they form the largest number.
#
#   For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.
#
#   One line Ruby:
#   https://leetcode.com/submissions/detail/53463704/
#
#   Submission Details
#   221 / 221 test cases passed.
#       Status: Accepted
#       Runtime: 76 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of ruby submissions.

def largest_number(nums)
    nums.map { |x| x.to_s }.sort { |x, y| (x + y) <=> (y + x) }.reverse.join.sub(/^0+/, "0")
end
