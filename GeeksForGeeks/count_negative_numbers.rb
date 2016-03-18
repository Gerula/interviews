#   http://www.geeksforgeeks.org/count-negative-numbers-in-a-column-wise-row-wise-sorted-matrix/
#   Find the number of negative numbers in a column-wise / row-wise sorted matrix M[][].
#   Suppose M has n rows and m columns.

require 'test/unit'
extend Test::Unit::Assertions

def count(matrix)
    i, j = 0, matrix[0].size - 1
    count = 0
    while i < matrix.size && j >= 0
        if matrix[i][j] < 0
            count += j + 1
            i += 1
        else
            j -= 1
        end
    end

    return count
end

assert_same(4, count([[-3, -2, -1,  1],
                      [-2,  2,  3,  4],
                      [ 4,  5,  7,  8]]))
