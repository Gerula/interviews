# http://careercup.com/question?id=5200686994161664
#
# Given an array int32 arr[] of size n, return the number of non-empty contigious subarrays whose sum lies in range [a, b]
#

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def subarrays(low, high)
        result = 0
        for i in 0...self.size
            for j in 1..self.size - i
                result += 1 if self[i, j].reduce(:+).between?(low, high)
            end
        end

        result
    end
end

assert_equal(4, [1, 2, 3].subarrays(0, 3))
assert_equal(3, [-2, 5, -1].subarrays(-2, 2))
