#   https://leetcode.com/problems/basic-calculator-ii/
#   Implement a basic calculator to evaluate a simple expression string.
#
#   The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.
#
#   You may assume that the given expression is always valid.
#   https://leetcode.com/submissions/detail/54103805/
#
#   Submission Details
#   109 / 109 test cases passed.
#       Status: Accepted
#       Runtime: 416 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 75.00% of rubysubmissions. That's pretty fucking decent. I had to fish out a couple of bugs but they were mostly
#   related to ruby quirks and the writing code inside the browser thing. But in conclusion, pretty fucking decent for 10 mins of work.

require 'set'

@ops = ["+", "-", "*", "/"].to_set

def calculate(s)
    operators = []
    operands = []
    priorities = { "+" => 1, "-" => 1, "*" => 0, "/" => 0}
    tokens(s) { |c|
        if !@ops.include?(c)
            operands.push(c.to_i)
        else
            while operators.any? && priorities[operators[-1]] <= priorities[c]
                right = operands.pop
                left = operands.pop
                operands.push(compute(left, right, operators.pop))
            end
            
            operators.push(c)
        end
    }
    
    while operators.any?
        right = operands.pop
        left = operands.pop
        operands.push(compute(left, right, operators.pop))
    end
    
    operands[-1]
end

def tokens(s)
    acc = ""
    s.chars
    .select { |c| c != ' ' }
    .each { |c|
        if @ops.include?(c)
            yield(acc)
            yield(c)
            acc = ""
        else
            acc += c
        end
    }
    
    yield(acc) if !acc.empty?
end

def compute(a, b, op)
    case op
        when "+"  
        a + b
        when "-"  
        a - b
        when "*"  
        a * b
        when "/"  
        a / b
    end
end

