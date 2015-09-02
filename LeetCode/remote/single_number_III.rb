#  Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once.
#
#  For example:
#
#  Given nums = [1, 2, 1, 3, 2, 5], return [3, 5]. 
#

require 'test/unit'
extend Test::Unit::Assertions

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

assert_equal([3, 5], single_number([1, 2, 1, 3, 2, 5]))
