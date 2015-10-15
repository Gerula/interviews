# 3Sum Closest 
# Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. Return the sum of the three integers. You may assume that each input would have exactly one solution.
#
#     For example, given array S = {-1 2 1 -4}, and target = 1.
#
#     The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
#
# https://leetcode.com/submissions/detail/43060684/
#
#
# Submission Details
# 120 / 120 test cases passed.
#   Status: Accepted
#   Runtime: 160 ms
#       
#       Submitted: 0 minutes ago
#
#       You are here!
#       Your runtime beats 100.00% of ruby submissions.

require 'test/unit'
extend Test::Unit::Assertions

def three_sum_closest(nums, target)
    nums.sort!
    closest = nums[0...3].reduce(:+)
    0.upto(nums.size - 3).each { |start|
        middle = start + 1
        back = nums.size - 1
        while middle < back
            sum = nums[start] + nums[middle] + nums[back]
            return sum if sum == target
            middle += 1 if sum < target
            back -= 1 if sum > target
            closest = sum if (sum - target).abs < (closest - target).abs
        end
    }

    return closest
end

assert_equal(2, three_sum_closest([-1, 2, 1, -4], 1))
assert_equal(3, three_sum_closest([1, 1, 1, 1], 4))
assert_equal(0, three_sum_closest([0, 0, 0], 1))
assert_equal(3, three_sum_closest([0, 1, 2], 0))
