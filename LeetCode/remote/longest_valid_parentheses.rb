#   https://leetcode.com/problems/longest-valid-parentheses/
#
#   Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
#
#   For "(()", the longest valid parentheses substring is "()", which has length = 2.
#
#   Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4.
#

# First wrong attempt

# @param {String} s
# @return {Integer}
def longest_valid_parentheses(s)
    dp = Array.new(s.size) { 0 }
    max = 0
    for i in 1...s.size
        next if s[i] == '('
        dp[i] = 2 + (dp[i - 2] || 0) if s[i - 1] == '('
        dp[i] = 2 + dp[i - dp[i - 1]] if s[i - 1] == ')' && i - dp[i - 1] >= 0
        max = [max, dp[i]].max
    end
    
    return max
end
