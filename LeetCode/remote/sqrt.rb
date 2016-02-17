#   https://leetcode.com/problems/sqrtx/
#
#   Implement int sqrt(int x).

#   https://leetcode.com/submissions/detail/53699203/
#
#   Submission Details
#   1017 / 1017 test cases passed.
#       Status: Accepted
#       Runtime: 84 ms
#           
#           Submitted: 0 minutes ago

# @param {Integer} x
# @return {Integer}
def my_sqrt(x)
    return x if x < 2
    low = 0
    high = x
    while low < high
        mid = low + (high - low) / 2
        if mid <= x / mid
            low = mid + 1
        else
            high = mid
        end
    end
    
    return low - 1
end
