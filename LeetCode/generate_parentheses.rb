#  Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.
#
#  For example, given n = 3, a solution set is:
#
#  "((()))", "(()())", "(())()", "()(())", "()()()" 
#

def generate(s, left, right)
    if left == 0 && right == 0
        puts s
        return
    end

    if left > 0
        generate(s + "(", left - 1, right)
    end

    if right > left
        generate(s + ")", left, right - 1)
    end
end

generate("", 3, 3)
