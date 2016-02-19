#   https://leetcode.com/problems/search-insert-position/
#
#   Given a sorted array and a target value, return the index if the target is found.
#   If not, return the index where it would be if it were inserted in order.
#
#   You may assume no duplicates in the array.
#   https://leetcode.com/submissions/detail/53870440/
#
#   Submission Details
#   62 / 62 test cases passed.
#       Status: Accepted
#       Runtime: 80 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer[]} nums
# @param {Integer} target
# @return {Integer}
def search_insert(nums, target)
    low = 0
    high = nums.size
    while low < high
        mid = low + (high - low) / 2
        if nums[mid] == target
            return mid
        end
        
        if nums[mid] > target
            high = mid
        else
            low = mid + 1
        end
    end
    
    return low
end
