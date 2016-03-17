#   https://leetcode.com/problems/rotate-array/
#   Rotate an array of n elements to the right by k steps.
#
#   For example, with n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4].
#
#   Note:
#   Try to come up as many solutions as you can, there are at least 3 different ways to solve this problem. 

#   https://leetcode.com/submissions/detail/56510417/
#
#   Submission Details
#   33 / 33 test cases passed.
#       Status: Accepted
#       Runtime: 91 ms
#           
#           Submitted: 1 minute ago
#
def rotate(nums, k)
    k.times { 
        nums.unshift(nums.pop)
    }
end


