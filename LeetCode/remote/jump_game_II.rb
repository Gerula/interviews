#   https://leetcode.com/problems/jump-game-ii/
#
#    Given an array of non-negative integers, you are initially positioned at the first index of the array.
#
#    Each element in the array represents your maximum jump length at that position.
#
#    Your goal is to reach the last index in the minimum number of jumps.
#
#    For example:
#    Given array A = [2,3,1,1,4]
#
#    The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.) 

#   First attempt, TLE

# @param {Integer[]} nums
# @return {Integer}
def jump(nums)
    return 0 if nums.size <= 1
    queue = [0]
    level = 1
    next_level = 0
    while queue.any?
        current = queue.shift
        1.upto(nums[current]).each { |i|
            next_level += 1
            queue.push(current + i)
            return level if current + i == nums.size - 1
        }
        
        level, next_level = next_level, 0 if (level -= 1) == 0
    end
end

#   https://leetcode.com/submissions/detail/53101342/
#
#
#   Submission Details
#   91 / 91 test cases passed.
#       Status: Accepted
#       Runtime: 116 ms
#           
#           Submitted: 3 minutes ago
#
# @param {Integer[]} nums
# @return {Integer}
def jump(nums)
    edge = 0
    max = nums[0]
    steps = 0
    for i in 1...nums.size # Iterate over the array while keeping
                           # three states:
                           # - max - maximum current reach
                           # - edge - length of the maximum reach expanded since the last time we had to expand
                           # - steps - when expanding the reach, increase the number of steps
        if i > edge
            steps += 1
            edge = max
            return steps if edge >= nums.size - 1 
        end
        
        max = [max, i + nums[i]].max
    end
    
    return steps
end
