#   https://leetcode.com/problems/generate-parentheses/
#
#    Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
#
#    For example, given n = 3, a solution set is:
#
#    "((()))", "(()())", "(())()", "()(())", "()()()" 
#
#   https://leetcode.com/submissions/detail/54344900/
#
#   Submission Details
#   8 / 8 test cases passed.
#       Status: Accepted
#       Runtime: 92 ms
#           
#           Submitted: 0 minutes ago

#   Very beautiful solution

def generate_parenthesis(n)
    (1..n).inject([[""]]) { |acc, i|
        acc << (0...i).map { |x| acc[x].product(acc[i - x - 1]).map { |a, b| "(#{a})#{b}"} }.flatten
    }.last
end
