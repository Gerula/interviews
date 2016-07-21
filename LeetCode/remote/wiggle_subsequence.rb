#   https://leetcode.com/problems/wiggle-subsequence/
#   A sequence of numbers is called a wiggle sequence if the differences between successive numbers strictly alternate between positive and negative. The first difference (if one exists) may be either positive or negative. A sequence with fewer than two elements is trivially a wiggle sequence.
#
#   For example, [1,7,4,9,2,5] is a wiggle sequence because the differences (6,-3,5,-7,3) are alternately positive and negative. In contrast, [1,4,7,2,5] and [1,7,4,5,5] are not wiggle sequences, the first because its first two differences are positive and the second because its last difference is zero.
#
#   Given a sequence of integers, return the length of the longest subsequence that is a wiggle sequence. A subsequence is obtained by deleting some number of elements (eventually, also zero) from the original sequence, leaving the remaining elements in their original order.

#   Wrong answer on some stupid test case. Solution looks ok..
def wiggle_max_length(nums)
    return 0 if nums.empty?
    smaller, larger = Array.new(nums.size) { 1 }, Array.new(nums.size) { 1 }
    max = 1
    1.upto(nums.size - 1).each { |i|
        0.upto(i - 1).each { |j|
            if (nums[i] > nums[j])
                smaller[i] = [larger[j] + 1, smaller[i]].max
            else
                larger[i] = [smaller[j] + 1, larger[i]].max
            end
        }
        
        max = [max, smaller[i], larger[i]].max
    }
    
    return max
end
