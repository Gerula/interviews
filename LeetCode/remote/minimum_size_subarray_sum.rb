#   https://leetcode.com/problems/minimum-size-subarray-sum/
#
#    Given an array of n positive integers and a positive integer s, find the minimal length of a subarray of which the sum ≥ s.
#    If there isn't one, return 0 instead.
#
#    For example, given the array [2,3,1,2,4,3] and s = 7,
#    the subarray [4,3] has the minimal length under the problem constraint. 

#   https://leetcode.com/submissions/detail/53781536/
#
#   Submission Details
#   14 / 14 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer} s
# @param {Integer[]} nums
# @return {Integer}
def min_sub_array_len(s, nums)
    left = 0
    sum = 0
    min = nums.size + 1
    for right in 0...nums.size
        sum += nums[right]
        while sum >= s
            min = [min, right - left + 1].min
            sum -= nums[left]
            left += 1
        end
    end
    
    return min == nums.size + 1 ? 0 : min
end
