#   https://leetcode.com/problems/single-number-iii/
#
#   Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice.
#   Find the two elements that appear only once. 
#   
#   https://leetcode.com/submissions/detail/53730883/
#
#   Submission Details
#   30 / 30 test cases passed.
#       Status: Accepted
#       Runtime: 88 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer[]} nums
# @return {Integer[]}
def single_number(nums)
    xor = nums.inject { |acc, x| acc ^ x }
    last_digit = xor & (1 - xor)
    first, second = xor, xor
    nums.each { |x|
        if last_digit & x != 0
            first ^= x
        else
            second ^= x
        end
    }
    
    [first, second]
end
