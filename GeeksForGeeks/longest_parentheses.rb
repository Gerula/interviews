# http://www.geeksforgeeks.org/length-of-the-longest-valid-substring/
#
#  Given a string consisting of opening and closing parenthesis, find length of the longest valid parenthesis substring.
#  
#  This is a pushdown automata

require 'test/unit'
extend Test::Unit::Assertions

class String
    def longest
        stack = [-1]
        max = [0, 0]

        for i in 0...self.size
            if self[i] == "("
                stack.push(i)
            else
                stack.pop
                
                if stack.any?
                    max = [stack[-1] + 1, i + (stack[-1] == -1 ? 1 : 0)] if i - stack[-1] > max[1] - max[0]
                else
                    stack.push(i)
                end
            end
        end

        return self[max[0], max[1]]
    end
end

assert_equal("()", "((()".longest)
assert_equal("()()", ")()())".longest)
assert_equal("()(())", "()(()))))".longest)
