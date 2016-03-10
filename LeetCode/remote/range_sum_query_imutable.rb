#   https://leetcode.com/problems/range-sum-query-immutable/
#   Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.
#   https://leetcode.com/submissions/detail/55866439/
#   
#   Submission Details
#   16 / 16 test cases passed.
#       Status: Accepted
#       Runtime: 88 ms
#           
#           Submitted: 0 minutes ago
class NumArray
    def initialize(nums)
        @nums = nums
        @accumulator = nums.reduce([]) { |acc, x|
            acc << (acc.last || 0) + x
        }
    end

    def sum_range(i, j)
        @accumulator[j] - @accumulator[i] + @nums[i]
    end
end

class NumArray

    # Initialize your data structure here.
    # @param {Integer[]} nums
    def initialize(nums)
        @accumulator = nums.reduce([]) { |acc, x|
            acc << {:num => x, :sum => acc.last.nil? ? 0 : acc.last[:sum] + x }
        }
    end

    # @param {Integer} i
    # @param {Integer} j
    # @return {Integer}
    def sum_range(i, j)
        @accumulator[j][:sum] - @accumulator[i][:sum] + @accumulator[i][:num]
    end
end
