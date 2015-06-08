#  Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.
#
#  Follow up:
#
#  Did you use extra space?
#  A straight forward solution using O(mn) space is probably a bad idea.
#  A simple improvement uses O(m + n) space, but still not the best solution.
#  Could you devise a constant space solution?
#

matrix = [[0, 1, 1, 1, 0, 1],
          [1, 1, 1, 1, 1, 1],
          [1, 1, 0, 1, 1, 1],
          [1, 1, 1, 1, 1, 1],
          [1, 1, 1, 1, 1, 1],
          [1, 1, 1, 1, 1, 1]]


matrix.each { |x|
    puts x.inspect
}
puts

first_column_zero = false
first_row_zero = false

0.upto(matrix.size - 1).each { |i|
    if matrix[0][i] == 0
        first_row_zero = true
    end
    if matrix[i][0] == 0
        first_column_zero = true
    end
}

0.upto(matrix.size - 1).each { |i|
    0.upto(matrix.size - 1).each { |j|
        if matrix[i][j] == 0
            matrix[i][0] = 0
            matrix[0][j] = 0
        end
    }
}

1.upto(matrix.size - 1).each { |i|
    1.upto(matrix.size - 1).each { |j|
        if matrix[0][j] == 0 || matrix[i][0] == 0
            matrix[i][j] = 0
        end
    }
}

if first_row_zero
    0.upto(matrix.size - 1).each { |i|
        matrix[0][i] = 0
    }
end

if first_column_zero
    0.upto(matrix.size - 1).each { |i|
        matrix[i][0] = 0
    }
end

matrix.each { |x|
    puts x.inspect
}

puts
