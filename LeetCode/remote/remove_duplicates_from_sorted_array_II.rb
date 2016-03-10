#   https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
#    Follow up for "Remove Duplicates":
#    What if duplicates are allowed at most twice?
#
#    For example,
#    Given sorted array nums = [1,1,1,2,2,3],
#
#    Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3.
#    It doesn't matter what you leave beyond the new length. 
#    https://leetcode.com/submissions/detail/55928207/
#
#    Submission Details
#    164 / 164 test cases passed.
#       Status: Accepted
#       Runtime: 88 ms
#           
#           Submitted: 0 minutes ago
#   You are here!
#   Your runtime beats 100.00% of rubysubmissions.
def remove_duplicates(nums)
    write = 0
    (0...nums.size).each { |i|
        next if write > 1 && nums[i] == nums[write - 2]
        nums[write] = nums[i]
        write += 1
    }
    
    write
end
