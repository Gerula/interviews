#   https://leetcode.com/problems/jump-game/
#
#    Given an array of non-negative integers, you are initially positioned at the first index of the array.
#
#    Each element in the array represents your maximum jump length at that position.
#
#    Determine if you are able to reach the last index.

#   https://leetcode.com/submissions/detail/53635509/
#
#   Submission Details
#   72 / 72 test cases passed.
#       Status: Accepted
#       Runtime: 104 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer[]} nums
# @return {Boolean}
def can_jump(nums)
    edge = -1
    max = -1
    0.upto(nums.size - 1).each { |i|
        if i >= edge
            edge = max
        end
        
        max = [max, i + nums[i]].max
        return false if max == i && i < nums.size - 1
    }
    
    return true
end

#   https://leetcode.com/submissions/detail/58061413/
#
#   Submission Details
#   72 / 72 test cases passed.
#       Status: Accepted
#       Runtime: 116 ms
#           
#           Submitted: 0 minutes ago
def can_jump(nums)
    max = nums.first
    nums.drop(1).each { |x|
        return false if (max -= 1) < 0
        max = [max, x].max
    }

    return true
end
