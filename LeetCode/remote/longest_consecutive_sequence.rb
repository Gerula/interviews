#   https://leetcode.com/problems/longest-consecutive-sequence/
#
#    Given an unsorted array of integers, find the length of the longest consecutive elements sequence.
#
#    For example,
#    Given [100, 4, 200, 1, 3, 2],
#    The longest consecutive elements sequence is [1, 2, 3, 4]. Return its length: 4.
#
#    Your algorithm should run in O(n) complexity. 

#   
#   Submission Details
#   67 / 67 test cases passed.
#       Status: Accepted
#       Runtime: 92 ms
#           
#           Submitted: 1 minute ago
#

# @param {Integer[]} nums
# @return {Integer}
def longest_consecutive(nums)
    hash = nums.inject({}) { |acc, x|
        acc[x] = 1
        acc
    }
    
    nums.inject(0) { |acc, x|
        up = 0
        while !hash[x + up].nil?
            hash.delete(x + up)
            up += 1
        end
        down = -1
        while !hash[x + down].nil?
            hash.delete(x + down)
            down -= 1
        end
        
        [acc, up + down.abs - 1].max
    }
end
