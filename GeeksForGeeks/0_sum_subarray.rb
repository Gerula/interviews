# http://www.geeksforgeeks.org/find-the-largest-subarray-with-0-sum/
#
# Given an array of integers, find length of the largest subarray with sum equals to 0.
#

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def max_0_sum
        sums = [self.first]
        for i in 1...self.size
            sums << sums.last + self[i]
        end

        sums.each_with_index.inject({}) { |acc, x|
            acc[x[0]] ||= []
            acc[x[0]] << x[1]
            acc
        }.map { |x| 
            if x[0] == 0
                x[1]
            elsif x[1].size > 1
                x[1].last - x[1].first
            else
                0
            end
        }.max
    end
end

assert_equal(5, [15, -2, 2, -8, 1, 7, 10, 23].max_0_sum)
assert_equal(0, [1, 2, 3].max_0_sum)
assert_equal(1, [1, 0, 3].max_0_sum)
