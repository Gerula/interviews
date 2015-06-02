# Given numRows, generate the first numRows of Pascal's triangle.
#
# For example, given numRows = 5,
# Return
#
# [
#  [1],
#  [1,1],
#  [1,2,1],
#  [1,3,3,1],
#  [1,4,6,4,1]
# ]
#

def pascal(numRows)
    result = [[1]]
    2.upto(numRows).each { |row|
        partial_result = Array.new(row)
        previous_result = result[-1]
        0.upto(partial_result.size - 1).each {|i|
            prev = i == 0 ? 0 : previous_result[i - 1]
            current = i == partial_result.size - 1 ? 0: previous_result[i]
            partial_result[i] = prev + current
        } 
        result << partial_result
    }

    result
end

puts pascal(5).inspect
