# Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n. 

require 'test/unit'
extend Test::Unit::Assertions

class Fixnum
    def square_sum
        # 1 - [1] - 1
        # 2 - [1, 1] - 2
        # 3 - [1, 1, 1] - 3
        # 4 - [4] - 1
        # 5 - [1, 4] - 2
        # 6 - [2, 4] - 2
        # 7 - [1, 2, 4] - 3
        # 8 - [4, 4] - 2
        # 9 - [1, 4, 4] - 3
        # 10 - [1, 9] - 2
        # 11 - [1, 1, 9] - 3
        # 12 - [4, 4, 4] - 3
        # 13 - [4, 9] - 2
        dp = [0]
        for i in 1..self
            squares = 2 ** 0.size * 8
            1.upto(i ** 0.5).each { |j|
                squares = [squares, dp[i - j * j] + 1].min
            }

            dp[i] = squares 
        end

        return dp[self]
    end
end

assert_equal(3, 12.square_sum)
assert_equal(2, 13.square_sum)

