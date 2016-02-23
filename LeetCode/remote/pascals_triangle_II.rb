#   https://leetcode.com/problems/pascals-triangle-ii/
#
#   Given an index k, return the kth row of the Pascal's triangle.
#   https://leetcode.com/submissions/detail/54259121/
#   Submission Details
#   34 / 34 test cases passed.
#       Status: Accepted
#       Runtime: 80 ms
#           
#           Submitted: 0 minutes ago

def get_row(row_index)
    (1..row_index).inject([1]) { |acc, x| [1] + acc.each_cons(2).map {|a, b| a + b } + [1] }
end
