require 'test/unit'
extend Test::Unit::Assertions

class Array
    def max_cross
        left, right, up, down = {}, {}, {}, {}
        n = self.size
        for i in 0...n
            for j in 0...n
                up[[i, j]] = 0
                up[[i, j]] = (up[[i - 1, j]].nil? ? 0 : up[[i - 1, j]]) + 1 if i > 0 && self[i - 1][j] == 1
                left[[i, j]] = 0
                left[[i, j]] = (left[[i, j - 1]].nil? ? 0 : left[[i, j - 1]]) + 1 if i > 0 && self[i][j - 1] == 1
                down[[n - i - 1, j]] = 0
                down[[n - i - 1, j]] = (down[[n - i - 2, j]].nil? ? 0 : down[[n - i - 2, j]]) + 1 if i < n - 1 && self[n - i - 2][j] == 1
                right[[i, n - j - 1]] = 0
                right[[i, n - j - 1]] = (right[[i, n - j - 2]].nil? ? 0 : right[[i, n - j - 2]]) + 1 if j < n - 1 && self[i][n - j - 2] == 1
            end
        end

        max = 0
        for i in 0...n
            for j in 0...n
                max = [max, [up[[i, j]], left[[i, j]], down[[i, j]], right[[i, j]]].min * 4 + 1].max if self[i][j] == 1
            end
        end

        return max
    end
end

assert_equal(5, [[0, 0, 0, 0],
                 [1, 1, 0, 1],
                 [1, 1, 1, 1],
                 [1, 1, 1, 0]].max_cross)

assert_equal(9, [[0, 0, 1, 0, 0],
                 [1, 0, 1, 1, 0],
                 [1, 1, 1, 1, 1],
                 [1, 1, 1, 1, 0],
                 [1, 1, 1, 0, 0]].max_cross)

