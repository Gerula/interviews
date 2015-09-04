require 'test/unit'
extend Test::Unit::Assertions

class Array
    def min_points
        n = self.size
        m = self[0].size
        max_int = 2 ** (0.size * 8)
        for i in 0...n
            for j in 0...m
                next if i == 0 && j == 0
                up = i > 0 ? self[i - 1][j] : max_int
                left = j > 0 ? self[i][j - 1] : max_int
                self[i][j] = (i == n - 1 && j == m - 1 ? self[i][j] : 0) + [up, left].min
            end
        end

        return self[n - 1][m - 1] < 0 ? self[n - 1][m - 1].abs : 0 
    end
end

assert_equal(7,
             [[-2,  -3,  3],
              [-5, -10,  1],
              [10,  30, -5]].min_points)
