#  Evaluate the value of an arithmetic expression in Reverse Polish Notation.
#
#  Valid operators are +, -, *, /. Each operand may be an integer or another expression.
#
#  Some examples:
#
#    ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
#    ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6
#

class Array
    def operators
        ["*", "/", "+", "-"]
    end

    def evaluate
        stack = []
        self.each { |token|
            if operators.include?(token)
                compute(stack, token)
            else
                stack.push(token)
            end
        }

        stack.pop
    end

    def eval
        operator_stack = []
        operand_stack = []
        
        self.each { |token|
            if operators.include?(token)
                while operator_stack.any? && operators.index(operator_stack[-1]) <= operators.index(token)
                    compute(operand_stack, operator_stack.pop)
                end
                operator_stack.push(token)     
            else
                operand_stack.push(token)
            end      
        }

        while operator_stack.any?
            compute(operand_stack, operator_stack.pop)
        end

        operand_stack.first
    end

    def compute(operands, operator)
        b = operands.pop.to_i
        a = operands.pop.to_i
        case operator
        when "+" then operands.push(a + b)
        when "-" then operands.push(a - b)
        when "*" then operands.push(a * b)
        when "/" then operands.push(a / b)
        end
    end
end

[["2", "1", "+", "3", "*"], ["4", "13", "5", "/", "+"]].each { |s|
    puts s.evaluate
}

["2 * 3 + 4 * 10 + 2".split, "1 + 2 + 4 * 5".split].each { |s|
    puts s.eval
}
