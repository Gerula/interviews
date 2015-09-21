# https://leetcode.com/problems/search-in-rotated-sorted-array/
#
# Suppose a sorted array is rotated at some pivot unknown to you beforehand.
#
# (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
#
# You are given a target value to search. If found in the array return its index, otherwise return -1.
#
# You may assume no duplicate exists in the array.
# 
# 194 / 194 test cases passed.
#   Status: Accepted
#   Runtime: 84 ms
#       
#       Submitted: 0 minutes ago
# 
#  You are here!
#  Your runtime beats 0.00% of ruby submissions.
#
# https://leetcode.com/submissions/detail/40571867/

require 'test/unit'
extend Test::Unit::Assertions

def search(nums, target)
    low = 0
    high = nums.size - 1
    while low <= high
        mid = low + (high - low) / 2
        return mid if nums[mid] == target

        if nums[low] <= nums[mid]
            if target.between?(nums[low], nums[mid])
                high = mid - 1
            else
                low = mid + 1
            end
        else
            if target.between?(nums[mid], nums[high])
                low = mid + 1
            else
                high = mid - 1
            end
        end
    end

    return -1
end

assert_equal(-1, search([4, 5, 6, 7, 0, 1, 2], 3))
assert_equal(2, search([4, 5, 6, 7, 0, 1, 2], 6))
assert_equal(1, search([4, 5, 6, 7, 0, 1, 2], 5))
assert_equal(1, search([1, 2, 3, 4, 5, 6, 7], 2))
assert_equal(3, search([6, 7, 1, 2, 3, 4, 5], 2))
