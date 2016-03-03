#   https://leetcode.com/problems/basic-calculator/
#
#   Implement a basic calculator to evaluate a simple expression string.
#
#   The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, non-negative integers and empty spaces .
#
#   You may assume that the given expression is always valid.
#   I love this problem. It's so beautiful..
#   https://leetcode.com/submissions/detail/55225743/
#
#   Submission Details
#   37 / 37 test cases passed.
#       Status: Accepted
#       Runtime: 476 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.
# @param {String} s
# @return {Integer}

@operators = { "(" => 0, ")" => 1, "+" => 2, "-" => 2, "*" => 3, "/" => 4 }

def calculate(s)
    operators = []
    operands = []
    tokens(s) { |token|
        if !@operators.include?(token)
            operands << token.to_i
            next
        end
        
        case token
            when "("
                operators.push(token)
            when ")"
                while operators[-1] != "("
                    compute(operators, operands)
                end

                operators.pop
            else
                if operators.any? && @operators[operators[-1]] >= @operators[token]
                    compute(operators, operands)
                end
                
                operators.push(token)
        end
        
    }
    
    while operators.any?
        compute(operators, operands)
    end
    
    operands.first
end

def compute(operators, operands)
    b = operands.pop
    a = operands.pop
    op = operators.pop
    operands << case op
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

def tokens(s)
    token = ""
    s.chars.each { |c|
        next if c == " "
        if @operators.include?(c)
            yield token unless token.chars.empty?
            token = ""
            yield c
        else
            token += c
        end
    }
    
    yield token if token.chars.any?
end
