# http://www.geeksforgeeks.org/find-all-possible-outcomes-of-a-given-expression/
#
# Given an arithmetic expression, find all possible outcomes of this expression. Different outcomes are evaluated by putting brackets at different places.
#
# We may assume that the numbers are single digit numbers in given expression.
#

require "test/unit"
extend Test::Unit::Assertions

def outcomes(expression)
    result = []
    expression.each_with_index { |x, i|
        if["+", "*", "-", "/"].include?(x)
            left = outcomes(expression[0...i])
            right = outcomes(expression[i + 1..-1])
            left.each { |i|
                right.each { |j|
                    case x
                        when "+" then result << i.to_i + j.to_i
                        when "-" then result << i.to_i - j.to_i
                        when "*" then result << i.to_i * j.to_i
                        when "/" then result << i.to_i / j.to_i
                    end
                }
            }
        end
    }

    result << expression.first if expression.size == 1

    return result
end

assert_equal([7, 8], outcomes("1+3*2".chars))
assert_equal([14, 20, 14, 20, 20], outcomes("1*2+3*4".chars))
