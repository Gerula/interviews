#   https://leetcode.com/problems/maximum-gap/
#   Given an unsorted array, find the maximum difference between the successive elements in its sorted form.
#
#   Try to solve it in linear time/space.
#
#   Return 0 if the array contains less than 2 elements.
#
#   You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.
#   https://leetcode.com/submissions/detail/55263569/
#
#   Submission Details
#   17 / 17 test cases passed.
#       Status: Accepted
#       Runtime: 154 ms
#           
#           Submitted: 0 minutes ago
def maximum_gap(nums)
    radix(nums, 1)
    .each_cons(2)
    .map { |x, y| y - x }
    .max || 0
end

def radix(nums, digit)
    return nums if digit > 1000000000
    radix(
        nums.inject({}) { |acc, x|
            index = x / digit % 10
            acc[index] ||= []
            acc[index] << x
            acc
        }
        .sort
        .map { |x, y| y }
        .flatten,
        digit * 10)
end
