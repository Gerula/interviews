# You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
#
# Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
#

require 'test/unit'
extend Test::Unit::Assertions

def rob(nums)
    pre = current = 0
    nums.each { |x|
        temp = [pre + x, current].max
        pre = current
        current = temp
    }

    return current
end

assert_equal(25, rob([1, 2, 3, 4, 5, 6, 7, 8, 9]))
