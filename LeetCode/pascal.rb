# Pascal's Triangle Total Accepted: 50771 Total Submissions: 168463
#
# Given numRows, generate the first numRows of Pascal's triangle.
#
# For example, given numRows = 5,
# Return
#
# [
#      [1],
#      [1,1],
#      [1,2,1],
#      [1,3,3,1],
#      [1,4,6,4,1]
# ]
#
# Wrote in browser directly
#
# 15 / 15 test cases passed.
#   Status: Accepted
#   Runtime: 76 ms
#       
#       Submitted: 0 minutes ago
#

def generate(num_rows)
    1.upto(num_rows).inject([]) { |acc, x|
        if acc.empty?
            acc << [1]
        else
            acc << [1] + acc.last.each_cons(2).map { |a, b| a + b } + [1]
        end
    }
end
