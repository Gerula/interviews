#   https://leetcode.com/problems/two-sum/
#   Given an array of integers, return indices of the two numbers such that they add up to a specific target.
#
#   You may assume that each input would have exactly one solution.
#
#   https://leetcode.com/submissions/detail/54461573/
#
#   Submission Details
#   16 / 16 test cases passed.
#       Status: Accepted
#       Runtime: 76 ms
#           
#           Submitted: 0 minutes ago

def two_sum(nums, target)
    hash = {}
    (0...nums.size).each { |i|
        return [hash[target - nums[i]], i] if !hash[target - nums[i]].nil?
        hash[nums[i]] = i
    }
    
    nil
end
