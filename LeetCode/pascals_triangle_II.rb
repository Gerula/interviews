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
        result = 0.upto(i - 2).map { |j|
            acc[j] + acc[j + 1]
        }
        [1] + result + [1]
    } 
end

puts kth_row(10).inspect
