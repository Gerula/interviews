# https://leetcode.com/problems/expression-add-operators/
#  Given a string that contains only digits 0-9 and a target value,
#  return all possibilities to add operators +, -, or *
#  between the digits so they evaluate to the target value. 

require 'test/unit'
extend Test::Unit::Assertions

def add_operators(num, target)
    result = []
    return result if num.size < 2
    build_expression(num.chars, 1, target, num.chars.first.to_i, num.chars.first, result)
    return result
end

def build_expression(num, index, target, partial, expression, result) 
    if index == num.size
        result << expression if partial == target
        return
    end

    current = num[index].to_i
    ["+", "-", "*"].each { |op|
        case op
        when "*" 
                build_expression(num, 
                                index + 1, 
                                target, 
                                partial * current,
                                "#{expression}*#{current}",
                                result)
        when "+" 
                build_expression(num, 
                                 index + 1, 
                                 target, 
                                 partial + current,
                                 "#{expression}+#{current}",
                                 result)
        when "-" 
                build_expression(num, 
                                 index + 1, 
                                 target, 
                                 partial - current,
                                 "#{expression}-#{current}",
                                 result)
        end
    }
end

assert_equal(["1+2+3", "1*2*3"], add_operators("123", 6))
assert_equal(["2*3+2", "2+3*2"], add_operators("232", 8))
assert_equal(["0+0", "0-0", "0*0"], add_operators("00", 0))
assert_equal([], add_operators("3456237490", 9191))

