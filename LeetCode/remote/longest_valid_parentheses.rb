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
#  https://leetcode.com/submissions/detail/53794023/
#
#  Submission Details
#  229 / 229 test cases passed.
#   Status: Accepted
#   Runtime: 144 ms
#       
#       Submitted: 0 minutes ago
# No matter what they say, this is a hard fucking problem
def longest_valid_parentheses(s)
    dp = Array.new(s.size) { 0 }
    max = 0
    for i in 1...s.size
        next if s[i] == '('
        dp[i] = 2 + (dp[i - 2] || 0) if s[i - 1] == '('
        dp[i] = 2 + dp[i - 1] + (dp[i - dp[i - 1] - 2] || 0) if s[i - 1] == ')' && 
                                                                i - dp[i - 1] - 1 >= 0 && 
                                                                s[i - dp[i - 1] - 1] == '('
        max = [max, dp[i]].max
    end 
    return max
end

#   https://leetcode.com/submissions/detail/53795059/   
#
#   Submission Details
#   229 / 229 test cases passed.
#       Status: Accepted
#       Runtime: 128 ms
#           
#           Submitted: 0 minutes ago
#   Very smart solution. Too bad it's not mine..
def longest_valid_parentheses(s)
    stack = []
    for i in 0...s.size
        if s[i] == '('
            stack.push(i)
        else
            if stack.any? && s[stack[-1]] == '('
                stack.pop
            else
                stack.push(i)
            end
        end
    end
    
    return s.size if stack.empty?
    high = s.size
    low = 0
    max = 0
    while stack.any?
        low = stack.pop
        max = [max, high - low - 1].max
        high = low
    end
    
    [max, high].max
end
