#   https://leetcode.com/problems/maximum-subarray/
#
#    Find the contiguous subarray within an array (containing at least one number) which has the largest sum. 
#   
#   https://leetcode.com/submissions/detail/53778667/
#
#   Submission Details
#   201 / 201 test cases passed.
#       Status: Accepted
#       Runtime: 108 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer[]} nums
# @return {Integer}
def max_sub_array(nums)
    max_local = nums[0]
    max_total = nums[0]
    nums[1..-1].each { |x|
        max_local = [x, max_local + x].max
        max_total = [max_local, max_total].max
    }
    
    max_total
end
