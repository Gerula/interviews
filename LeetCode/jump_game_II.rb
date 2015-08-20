#  Given an array of non-negative integers, you are initially positioned at the first index of the array.
#
#  Each element in the array represents your maximum jump length at that position.
#
#  Your goal is to reach the last index in the minimum number of jumps.
#
#  For example:
#  Given array A = [2,3,1,1,4]
#
#  The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.) 
#
# https://leetcode.com/submissions/detail/36935943/

require 'test/unit'
extend Test::Unit::Assertions

def jump(nums)
    level = 0
    next_level = 0
    steps = 1
    i = 0
    return 0 if nums.nil? || nums.size <= 1
    while i <= level
        next_level = [nums[i] + i, next_level].max
        if next_level >= nums.size - 1
            return steps
        end
        
        if i == level
            level = next_level
            steps += 1
        end
        i += 1
    end

    return nil
end

def jmp(nums)
    queue = [0]
    current_level = 1
    next_level = 0
    steps = 0
    while queue.any?
        i = queue.shift
        current_level -= 1
        1.upto(nums[i]).each { |j|
            queue.push(i + j)
            if i + j >= nums.size
                return steps
            end
            next_level += 1
        } 

        if current_level == 0
            steps += 1
            current_level = next_level
            next_level = 0
        end
    end

    return nil
end

assert_equal(2, jump([2, 3, 1, 1, 4]))
assert_equal(2, jmp([2, 3, 1, 1, 4]))
