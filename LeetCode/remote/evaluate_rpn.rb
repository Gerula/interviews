#   https://leetcode.com/problems/evaluate-reverse-polish-notation/
#    Evaluate the value of an arithmetic expression in Reverse Polish Notation.
#
#    Valid operators are +, -, *, /. Each operand may be an integer or another expression.
#
#    Some examples:
#
#   ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
#   ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
#   
#   https://leetcode.com/submissions/detail/54831295/
#
#   Submission Details
#   20 / 20 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.

def eval_rpn(tokens)
    tokens.inject([]) { |acc, x|
        case x
            when "*", "-", "/", "+"
                evaluate(acc, x)
            else
                acc << x.to_i
        end
        
        acc
    }.pop
end

def evaluate(acc, op)
    b = acc.pop
    a = acc.pop
    acc << case op
            when "*"
                a * b
            when "/"
                (a / b.to_f).to_i
            when "-"
                a - b
            when "+"
                a + b
           end
end
