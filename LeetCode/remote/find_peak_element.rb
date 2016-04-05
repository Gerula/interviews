#   https://leetcode.com/problems/find-peak-element/
#   A peak element is an element that is greater than its neighbors.
#
#   Given an input array where num[i] ≠ num[i+1], find a peak element and return its index.
#
#   The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.
#
#   You may imagine that num[-1] = num[n] = -∞.
#   https://leetcode.com/submissions/detail/58175467/
#
#   Submission Details
#   58 / 58 test cases passed.
#       Status: Accepted
#       Runtime: 76 ms
#           
#           Submitted: 1 minute ago
# @param {Integer[]} nums
# @return {Integer}
def find_peak_element(nums)
    low = 0
    high = nums.size
    while low < high
        mid = low + (high - low) / 2
        return mid if (mid == 0 || nums[mid - 1] < nums[mid]) &&
                      (mid == nums.size - 1 || nums[mid + 1] < nums[mid])
                      
        if nums[mid - 1] <= nums[mid]
            low = mid + 1
        else
            high = mid
        end 
    end
    
    return low
end
