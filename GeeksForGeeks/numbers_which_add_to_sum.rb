# http://www.geeksforgeeks.org/count-of-n-digit-numbers-whose-sum-of-digits-equals-to-given-sum/
#

require 'test/unit'
extend Test::Unit::Assertions

def add_up(n, sum)
    result = []
    add_up_recursive(0, 0, n, sum, result)
    return result
end

def add_up_recursive(digits, current, n, sum, result) 
    if digits == n
        result << current if sum == 0
        return
    end

    0.upto(9).each { |i| 
        if current == 0 && i == 0 || sum - i < 0
            next
        end

        add_up_recursive(digits + 1, current * 10 + i, n, sum - i, result)
    }
end

assert_equal([11, 20], add_up(2, 2))
assert_equal([14, 23, 32, 41, 50], add_up(2, 5))
assert_equal([15, 24, 33, 42, 51, 60], add_up(2, 6))
