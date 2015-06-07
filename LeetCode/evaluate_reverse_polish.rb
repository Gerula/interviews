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
        ["*", "+", "/", "-"]
    end

    def evaluate
        stack = []
        self.each { |token|
            if operators.include?(token)
                b = stack.pop.to_i
                a = stack.pop.to_i
                case token
                when "+" then stack.push(a + b)
                when "-" then stack.push(a - b)
                when "*" then stack.push(a * b)
                when "/" then stack.push(a / b)
                end
            else
                stack.push(token)
            end
        }

        stack.pop
    end
end

[["2", "1", "+", "3", "*"], ["4", "13", "5", "/", "+"]].each { |s|
    puts s.evaluate
}
