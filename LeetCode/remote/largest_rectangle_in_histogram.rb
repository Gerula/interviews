#   https://leetcode.com/problems/largest-rectangle-in-histogram/
#
#    Given n non-negative integers representing the histogram's bar height where the width of each bar is 1,
#    find the area of largest rectangle in the histogram. 
#   
#   https://leetcode.com/submissions/detail/53973755/
#
#   Submission Details
#   94 / 94 test cases passed.
#       Status: Accepted
#       Runtime: 124 ms
#           
#           Submitted: 11 minutes ago

# @param {Integer[]} heights
# @return {Integer}
# Very nice idea to pad the heights array with zeroes.. this way you don't need to
# neither evacuate the stack nor check for empty stack
def largest_rectangle_area(heights)
    return 0 if heights.empty?
    return heights[0] if heights.size == 1
    stack = [0]
    max = 0
    heights.push(0)
    heights.unshift(0)
    for i in 0...heights.size
        while heights[i] < heights[stack[-1]]
            top = stack.pop
            max = [max, heights[top] * (i - stack[-1] - 1)].max
        end
        stack.push(i)
    end
    
    max
end
