#   https://leetcode.com/problems/gray-code/
#   The gray code is a binary numeral system where two successive values differ in only one bit.
#
#   Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code.
#   A gray code sequence must begin with 0.
#   https://leetcode.com/submissions/detail/55287144/
#
#   Submission Details
#   12 / 12 test cases passed.
#       Status: Accepted
#       Runtime: 108 ms
#           
#           Submitted: 0 minutes ago
def gray_code(n)
    return [0] if n == 0
    (1...n).inject([[0], [1]]) { |acc, x|
        acc = acc.map { |i| [0] + i } + acc.reverse.map { |i| [1] + i }
    }.map { |x| to_decimal(x) }
end

def to_decimal(nums)
    (0...nums.size).map { |x| nums[nums.size - x - 1] * 2 ** x }.reduce(:+)
end
