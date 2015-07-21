# Minimum Size Subarray Sum Total Accepted: 10659 Total Submissions: 46048
#
# Given an array of n positive integers and a positive integer s, find the minimal length of a subarray of which the sum ≥ s. If there isn't one, return 0 instead.
#
# For example, given the array [2,3,1,2,4,3] and s = 7,
# the subarray [4,3] has the minimal length under the problem constraint. 
#
#

# naive, time limit exceeded
def min_sub_array_len(s, nums)
    min = nums.size + 1
    for i in 0..nums.size - 1
        for j in i..nums.size - 1
            if nums[i..j].reduce(:+) >= s
                min = [min, j - i + 1].min
            end
        end
    end 

    return min == nums.size + 1 ? 0 : min
end

# 13 / 13 test cases passed.
#   Status: Accepted
#   Runtime: 104 ms
#       
#       Submitted: 0 minutes ago
#
def min_sub_array_len_2(s, nums)
    min = 2 ** (0.size * 8 - 2)
    sum = 0
    start = 0
    for i in 0..nums.size - 1
        sum += nums[i]
        while sum >= s
            min = [min, i - start + 1].min
            sum -= nums[start]
            start += 1
        end
    end

    return min == 2 ** (0.size * 8 - 2) ? 0 : min
end

puts min_sub_array_len(7, [2,3,1,2,4,3])
puts min_sub_array_len_2(7, [2,3,1,2,4,3])
