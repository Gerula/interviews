#   https://leetcode.com/problems/trapping-rain-water/
#   Given n non-negative integers representing an elevation map where the width of each bar is 1,
#   compute how much water it is able to trap after raining. 
#   https://leetcode.com/submissions/detail/58225471/
#
#   Submission Details
#   315 / 315 test cases passed.
#       Status: Accepted
#       Runtime: 408 ms
#           
#           Submitted: 0 minutes ago
# @param {Integer[]} height
# @return {Integer}
def trap(height)
    return 0 if !height.any?
    (0...height.size).inject([]) { |acc, x|
        acc[x] = [x, x == 0 ? 0 : [acc[x - 1][1], height[x - 1]].max]
        acc
    }.zip(
        (0...height.size).to_a.reverse.inject([]) { |acc, x|
            acc[x] = [x, x == height.size - 1 ? 0 : [acc[x + 1][1], height[x + 1]].max]
            acc
        }
    ).map { |x, y|
        result = [x[1], y[1]].min - height[x[0]]
        result < 0 ? 0 : result
    }.inject(:+)
end

