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

0.upto(matrix.size-1).each { |i|
    0.upto(matrix[0].size-1).each { |j|
        if matrix[i][j] == 0
            0.upto(matrix.size-1).each { |k|
                matrix[i][k] = nil unless matrix[i][k] == 0
                matrix[k][j] = nil unless matrix[k][j] == 0
            }
        end
    }
}

matrix.each { |x|
    puts x.inspect
}
puts

matrix.each { |x|
    x.map!{ |x|
        x.nil? ? 0 : x
    }
}

matrix.each { |x|
    puts x.inspect
}

puts
