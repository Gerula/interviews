#  Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.
#
#  For example:
#
#  Given nums = [1, 2, 1, 3, 2, 5], return [3, 5]. 
#

require 'test/unit'
extend Test::Unit::Assertions

# https://leetcode.com/submissions/detail/38510320/
# 30 / 30 test cases passed.
#   Status: Accepted
#   Runtime: 88 ms
#       
#       Submitted: 0 minutes ago
#
def single_number(nums)
    nums.inject({}) { |acc, x|
        if acc[x]
            acc.delete(x)
        else
            acc[x] = true
        end

        acc
    }.keys
end

def single_number_2(nums)
    a_xor_b = nums.reduce(:^)
    last_bit = (a_xor_b & (a_xor_b - 1)) ^ a_xor_b
    a = b = 0
    nums.each { |x|
        if x & last_bit != 0
            a = a ^ x
        else
            b = b ^ x
        end
    }

    [a, b]
end

assert_equal([3, 5], single_number([1, 2, 1, 3, 2, 5]))
assert_equal([3, 5], single_number_2([1, 2, 1, 3, 2, 5]))
