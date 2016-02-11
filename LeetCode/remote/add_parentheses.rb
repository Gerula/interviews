#   https://leetcode.com/problems/different-ways-to-add-parentheses/
#
#   Given a string of numbers and operators,
#   return all possible results from computing all the different possible ways to group numbers and operators.
#   The valid operators are +, - and *.

#   
#   Submission Details
#   24 / 24 test cases passed.
#       Status: Accepted
#       Runtime: 128 ms
#           
#           Submitted: 0 minutes ago
#
#   https://leetcode.com/submissions/detail/53211103/

# @param {String} input
# @return {Integer[]}
def diff_ways_to_compute(input)
    result = []
    ops = ['+','*','-']
    0.upto(input.size - 1).each { |i|
        if ops.include?(input[i])
            diff_ways_to_compute(input[0...i]).each { |a|
                diff_ways_to_compute(input[i + 1..-1]).each { |b|
                    result << a - b if input[i] == '-'
                    result << a * b if input[i] == '*'
                    result << a + b if input[i] == '+'
                }
            }
        end
    }
    
    result << input.to_i if result.size == 0
    return result
end
