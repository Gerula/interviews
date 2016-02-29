#   https://leetcode.com/problems/kth-largest-element-in-an-array/
#   Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.
#
#   For example,
#   Given [3,2,1,5,6,4] and k = 2, return 5.
#
#   Note:
#   You may assume k is always valid, 1 ≤ k ≤ array's length.
#
#   https://leetcode.com/submissions/detail/54859755/
#
#   Submission Details
#   31 / 31 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago
#   
#   Big fucking struggle.
# @param {Integer[]} nums
# @param {Integer} k
# @return {Integer}
def find_kth_largest(nums, k)
    low = 0
    high = nums.size - 1
    k = nums.size - k
    while low < high
        pivot = nums[low + (high - low) / 2]
        left = low
        right = high
        while left < right
            if nums[left] >= pivot
                nums[left], nums[right] = nums[right], nums[left]
                right -= 1
            else
                left += 1
            end
        end
        
        left -= 1 if nums[left] > pivot
        if k <= left
            high = left
        else
            low = left + 1
        end
    end
    
    nums[k]
end
