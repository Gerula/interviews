#   https://leetcode.com/problems/remove-duplicates-from-sorted-array/
#
#    Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.
#
#    Do not allocate extra space for another array, you must do this in place with constant memory. 

#  
#  Submission Details
#  161 / 161 test cases passed.
#   Status: Accepted
#   Runtime: 112 ms
#       
#       Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/52796324/
#
# @param {Integer[]} nums
# @return {Integer}
def remove_duplicates(nums)
    return 0 if nums.nil? || nums.size == 0
    write = 1
    1.upto(nums.size - 1).each { |i|
        if nums[i] != nums[i - 1]
            nums[write] = nums[i]
            write += 1
        end
    }
    
    return write
end
