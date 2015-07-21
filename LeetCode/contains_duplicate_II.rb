# Contains Duplicate II Total Accepted: 15988 Total Submissions: 62693
#
# Given an array of integers and an integer k, find out whether there there are two distinct indices i and j in the array such that nums[i] = nums[j] and the difference between i and j is at most k. 
#
# 19 / 19 test cases passed.
#   Status: Accepted
#   Runtime: 96 ms
#       
#       Submitted: 0 minutes ago
# Wrote directly in teh browser
#

def contains_nearby_duplicate(nums, k)
    nums.each_with_index.inject({}) { |acc, x|
        if acc[x[0]]
             distance = x[1] - acc[x[0]]
             if distance <= k
                return true
             end
        end
        
        acc[x[0]] = x[1]
        acc
    }
    
    return false
end
