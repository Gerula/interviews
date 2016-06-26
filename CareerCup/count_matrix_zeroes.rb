#   https://careercup.com/question?id=5767203879124992

require 'test/unit'
extend Test::Unit::Assertions

def count(matrix)
    column = matrix[0].size - 1
    line = 0
    total = 0
    while line < matrix.size && column >= 0
        if matrix[line][column] == 1
            column -= 1
        else
            line += 1
            total += column + 1
        end
    end

    return total
end

assert_equal(3, count([[0, 0, 1],
                       [0, 1, 1],
                       [1, 1, 1]]))
assert_equal(4, count([[0, 0],
                       [0, 0]]))

