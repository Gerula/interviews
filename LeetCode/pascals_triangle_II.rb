# Given an index k, return the kth row of the Pascal's triangle.
#
# For example, given k = 3,
# Return [1,3,3,1].
#
# Note:
# Could you optimize your algorithm to use only O(k) extra space? 
#

def kth_row(k)
    2.upto(k).inject([1, 1]) { |acc, i|
        [1] + acc.each_cons(2).map { |a, b| a + b} + [1]
    } 
end

puts kth_row(3).inspect
