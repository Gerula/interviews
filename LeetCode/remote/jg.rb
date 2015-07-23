# https://leetcode.com/submissions/detail/33908135/ 
#

# @param {Integer[]} nums
# @return {Boolean}
def can_jump(nums)
    return true if nums.empty?
    
    max = nums.first
    nums[1..-1].each { |x|
        max -= 1    
        return false if max < 0
        max = [max, x].max
    }
    
    return true
end
