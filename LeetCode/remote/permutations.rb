#   https://leetcode.com/problems/permutations/
#
#    Given a collection of distinct numbers, return all possible permutations. 
#
#    Oh how I fucking hate Ruby flattening \ array ambiguities
#
#    https://leetcode.com/submissions/detail/53446432/
#
#
#    Submission Details
#    25 / 25 test cases passed.
#       Status: Accepted
#       Runtime: 96 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer[]} nums
# @return {Integer[][]}
def permute(nums)
    return [[]] if !nums.any?
    return [nums] if nums.size == 1
    result = []
    nums.each { |x|
        permute(nums - [x])
        .map { |y|
            y.unshift(x)
        }
        .each { |y|
            result << y
        }
    }
    
    return result
end
