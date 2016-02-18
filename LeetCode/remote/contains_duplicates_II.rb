#   https://leetcode.com/problems/contains-duplicate-ii/
#
#   Given an array of integers and an integer k,
#   find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the difference between i and j is at most k. 
#   https://leetcode.com/submissions/detail/53770217/
#
#   Submission Details
#   20 / 20 test cases passed.
#       Status: Accepted
#       Runtime: 88 ms
#           
#           Submitted: 3 minutes ago

def contains_nearby_duplicate(nums, k)
    hash = {}
    for i in 0...nums.size
        if !hash[nums[i]].nil?
            return true if i - hash[nums[i]] <= k
        end
        
        hash[nums[i]] = i
    end
    
    return false
end
