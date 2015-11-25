# http://careercup.com/question?id=5715287577985024
#
# Imagine a triangle:
#
# 5
# 9 6
# 4 6 8
# 0 7 1 5
#
# Sum the maxes from each line
#

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def max_lines
        # n * (n + 1) / 2 = m
        # n ^ 2 + n - 2 * m = 0
        # n = (-1 +- sqrt(1 + 8 * m)) / 2
        #
        # n = (-1 + sqrt(81)) / 2
        # n = 4

        levels = ((Math.sqrt(1 + 8 * self.size) - 1) / 2).to_i
        return (1..levels)
               .map{ |x| self[x * (x - 1) / 2, x].max }
               .reduce(:+)
    end
end

assert_equal(29, [5, 9, 6, 4, 6, 8, 0, 7, 1, 5].max_lines)
