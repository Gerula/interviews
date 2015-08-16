# https://leetcode.com/submissions/detail/36531864/

require 'test/unit'
extend Test::Unit::Assertions

def climb_stairs(n)
    result = [0, 1, 2]
    3.upto(n).each { |i|
        result[i] = result[i - 1] + result [i - 2]
    }
    return result[n]
end

assert_equal(2, climb_stairs(2))
assert_equal(5, climb_stairs(4))
assert_equal(8, climb_stairs(5))
assert_equal(13, climb_stairs(6))
assert_equal(21, climb_stairs(7))
assert_equal(34, climb_stairs(8))
assert_equal(55, climb_stairs(9))
assert_equal(89, climb_stairs(10))
