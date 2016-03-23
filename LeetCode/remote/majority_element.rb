#   https://leetcode.com/problems/majority-element/
#   Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.
#
#   You may assume that the array is non-empty and the majority element always exist in the array.
#
#   https://leetcode.com/submissions/detail/57089372/
#
#   Submission Details
#   42 / 42 test cases passed.
#       Status: Accepted
#       Runtime: 116 ms
#           
#           Submitted: 0 minutes ago
def majority_element(nums)
    majority = nums[0]
    majority_count = 1
    nums.drop(1).each { |x|
        majority_count += x == majority ? 1 : -1
        if majority_count == 0
            majority = x
            majority_count = 1
        end
    }
    
    majority
end
