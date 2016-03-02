# https://leetcode.com/problems/move-zeroes/
#
#  Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.
#
#  For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0]. 
#
# 
# Submission Details
# 21 / 21 test cases passed.
#   Status: Accepted
#   Runtime: 96 ms
#       
#       Submitted: 0 minutes ago
#

require 'test/unit'
extend Test::Unit::Assertions

def move_zeroes(nums)
    zeroes = 0
    write = 0
    
    for i in 0...nums.size
        if nums[i] != 0
            nums[write] = nums[i]
            write += 1
        else
            zeroes += 1
        end
    end

    for i in (nums.size - zeroes)...nums.size
        nums[i] = 0
    end
end

a = [0, 1, 0, 3, 12]
move_zeroes(a)
assert_equal([1, 3, 12, 0, 0], a)
a = [0, 0, 0, 1]
move_zeroes(a)
assert_equal([1, 0, 0, 0], a)

#   Shittier solution 💩
#
#   Submission Details
#   21 / 21 test cases passed.
#       Status: Accepted
#       Runtime: 116 ms
#           
#           Submitted: 0 minutes ago
def move_zeroes(nums)
    aux = nums.sort { |x, y| 
        if y == 0
            -1
        elsif x == 0
            1
        else 
            0
        end
    }
    
    (0...aux.size).each { |i|
        nums[i] = aux[i]
    }
end
