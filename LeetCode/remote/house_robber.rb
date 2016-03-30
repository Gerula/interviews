# You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
#
# Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
#

require 'test/unit'
extend Test::Unit::Assertions

def rob(nums)
    last = now = 0
    pre = {}
    nums.each { |x|
        if last + x >= now 
            max = last + x
        else
            max = now
        end
        last = now
        now = max
    }

    puts result.inspect
    return now
end

assert_equal(25, rob([1, 2, 3, 4, 5, 6, 7, 8, 9]))

# No idea what was going on above..
# https://leetcode.com/submissions/detail/57718789/
#
# Submission Details
# 69 / 69 test cases passed.
#   Status: Accepted
#   Runtime: 108 ms
#       
#       Submitted: 1 minute ago
#
def rob(nums, hash = nil)
    hash ||= {}
    return 0 if nums.nil? || nums.empty?
    return hash[nums] if hash[nums]
    hash[nums] = [nums.first + rob(nums.drop(2), hash), rob(nums.drop(1), hash)].max
end
