#   https://leetcode.com/problems/patching-array/
#   Given a sorted positive integer array nums and an integer n,
#   add/patch elements to the array such that any number in range [1, n]
#   inclusive can be formed by the sum of some elements in the array.
#   Return the minimum number of patches required.
#   https://leetcode.com/submissions/detail/55870656/
#
#   Submission Details
#   149 / 149 test cases passed.
#       Status: Accepted
#       Runtime: 76 ms
#           
#           Submitted: 0 minutes ago
def min_patches(nums, n)
    miss = 1
    patches = 0
    i = 0
    while miss <= n
        if i < nums.size && nums[i] <= miss
            miss += nums[i]
            i += 1
        else
            miss += miss
            patches += 1
        end
    end
    
    patches
end

