#  Given an array of citations (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index.
#
#  According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each."
#
#  For example, given citations = [3, 0, 6, 1, 5], which means the researcher has 5 papers in total and each of them had received 3, 0, 6, 1, 5 citations respectively. Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, his h-index is 3.
#
#  Note: If there are several possible values for h, the maximum one is taken as the h-index. 
#

require 'test/unit'
extend Test::Unit::Assertions

def h_index(citations)
    citations.sort!
    size = citations.size
    citations.each_with_index { |x, i|
        return size - i if x >= size - i
    }

    return 0
end

assert_equal(3, h_index([3, 0, 6, 1, 5]))
assert_equal(1, h_index([1, 1, 1, 1, 1, 1, 1, 1]))

