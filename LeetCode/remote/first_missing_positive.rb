#   https://leetcode.com/problems/first-missing-positive/
#
#    Given an unsorted integer array, find the first missing positive integer. 
#
#   Well this was a great fucking struggle considering I knew how the solution should work..
#   Just to remind you how weak and small you really are.
#   
#   https://leetcode.com/submissions/detail/54023547/
#   Submission Details
#   156 / 156 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer[]} nums
# @return {Integer}
def first_missing_positive(nums)
    for i in 0...nums.size
        while nums[i] - 1 != i && 
              nums[i].between?(1, nums.size) &&
              nums[nums[i] - 1] != nums[i]
              
            remote = nums[nums[i] - 1]
            nums[nums[i] - 1] = nums[i]
            nums[i] = remote
        end
    end
    puts "#{nums}"
    (0.upto(nums.size - 1).find { |i| nums[i] != i + 1 } || nums.size) + 1
end
