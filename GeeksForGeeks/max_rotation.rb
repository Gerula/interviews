# http://www.geeksforgeeks.org/find-maximum-value-of-sum-iarri-with-only-rotations-on-given-array-allowed/
#
# Find maximum value of Sum( i*arr[i]) with only rotations on given array allowed
#
# Given an array, only rotation operation is allowed on array. We can rotate the array as many times as we want. Return the maximum possbile of summation of i*arr[i].

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def max_rotation
        (1..self.size).each.map { |i|
            sum = self.each_with_index.inject(0) { |acc, x|
                acc += x[0] * x[1]
            }
            self.push(self.shift)
            sum
        }.max
    end
end

assert_equal(72, [1, 20, 2, 10].max_rotation)
assert_equal(330, [10, 1, 2, 3, 4, 5, 6, 7, 8, 9].max_rotation)
