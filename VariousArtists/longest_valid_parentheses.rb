#   https://leetcode.com/problems/longest-valid-parentheses/
#   Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.
#
#   For "(()", the longest valid parentheses substring is "()", which has length = 2.
#
#   Another example is ")()())", where the longest valid parentheses substring is "()()", which has length = 4. 
#   https://leetcode.com/submissions/detail/56128927/
#
#   Submission Details
#   229 / 229 test cases passed.
#       Status: Accepted
#       Runtime: 120 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.
#   Fucking struggle... :(
def longest_valid_parentheses(s)
    stack = []
    (0...s.size).each { |i|
        if s[i] == ')'
            if stack.any? && s[stack[-1]] == '('
                stack.pop
            else
                stack.push i
            end
        else
            stack.push i
        end
    }

    return s.size if stack.empty?
    stack << s.size
    prev = -1
    max = 0
    puts "#{stack}"
    stack.each { |x|
        max = [max, x - prev - 1].max
        prev = x
    }

    max
end

[["(()", 2],
 ["()", 2],
 ["())", 2],
 [")(", 0],
 [")()())", 4]].each { |s, result|
    puts "#{s} exp [#{result}] actual [#{longest_valid_parentheses(s)}]" 
}
