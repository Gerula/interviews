# Summary Ranges Total Accepted: 10408 Total Submissions: 54572
#
# Given a sorted integer array without duplicates, return the summary of its ranges.
#
# For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"]. 
#
# Written directly in the browser
#
# 27 / 27 test cases passed.
#   Status: Accepted
#   Runtime: 72 ms
#       
#       Submitted: 1 minute ago
#

# @param {Integer[]} nums
# @return {String[]}
def summary_ranges(nums)
   result = []
   i = 0
   while i < nums.size
        current = nums[i]
        start = i
        i += 1
        while i < nums.size && nums[i] == nums[i - 1] + 1
            i += 1
        end
        
        result <<  ((i - start - 1 == 0) ? "#{current}" : "#{current}->#{nums[i - 1]}")
   end
   
   result
end
