# https://leetcode.com/problems/expression-add-operators/
#  Given a string that contains only digits 0-9 and a target value,
#  return all possibilities to add operators +, -, or *
#  between the digits so they evaluate to the target value. 

require 'test/unit'
extend Test::Unit::Assertions

def add_operators(num, target)
    result = []
    return result if num.size < 2
    build_expression(num.chars, 1, target, num.chars.first, result)
    return result
end

def evaluate(string)
    if string.size == 1
        return string.to_i
    else
        return operator(string[0], string[1], evaluate(string[2..-1]))
    end
end

def operator(left ,op, right)
    case op
        when "*"
            return left.to_i * right.to_i
        when "+"
            return left.to_i + right.to_i
        when "-"
            return left.to_i - right.to_i
    end
end

def build_expression(num, index, target, expression, result) 
    if index == num.size
        result << expression if evaluate(expression) == target
        return
    end

    current = num[index].to_i
    ["+", "-", "*"].each { |op|
            build_expression(num, 
                            index + 1, 
                            target, 
                            "#{expression}#{op}#{current}",
                            result)
    }
end

assert_equal(["1+2+3", "1*2*3"], add_operators("123", 6))
assert_equal(["2*3+2", "2+3*2"], add_operators("232", 8))
assert_equal(["0+0", "0-0", "0*0"], add_operators("00", 0))
assert_equal([], add_operators("3456237490", 9191))

