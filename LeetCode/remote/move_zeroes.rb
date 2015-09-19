# https://leetcode.com/problems/move-zeroes/
#
#  Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
#
#  For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0]. 
#

require 'test/unit'
extend Test::Unit::Assertions

def move_zeroes(nums)
    read = 0
    write = nums.size - 1
    while read < write
        if nums[read] == 0
            nums[read], nums[write] = nums[write], nums[read]
            write -= 1
        else
            read += 1
        end
    end
end

a = [0, 1, 0, 3, 12]
move_zeroes(a)
assert_equal([1, 3, 12, 0, 0], a)
a = [0, 0, 0, 1]
move_zeroes(a)
assert_equal([1, 0, 0, 0], a)
