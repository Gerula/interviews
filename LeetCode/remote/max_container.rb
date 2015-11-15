# https://leetcode.com/problems/container-with-most-water/
#
# Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.
#
# Note: You may not slant the container. 
# 
# Container With Most Water
# Submission Details
# 45 / 45 test cases passed.
#   Status: Accepted
#   Runtime: 152 ms
#       
#       Submitted: 0 minutes ago
#

def max_area(height)
    max = -1
    low = 0
    high = height.size - 1

    while low < high
        max = [max, [height[low], height[high]].min * (high - low)].max
        if height[low] < height[high]
            low += 1
        else
            high -= 1
        end
    end

    return max
end

puts max_area([1, 2, 0, 4, 0, 6, 0])
