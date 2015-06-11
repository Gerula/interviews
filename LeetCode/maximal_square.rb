#  Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1's and return its area.
#
#  For example, given the following matrix:
#
#  1 0 1 0 0
#  1 0 1 1 1
#  1 1 1 1 1
#  1 0 0 1 0
#
#  Return 4. 
#

board = [[1, 0, 1, 0, 0],
         [1, 0, 1, 1, 1],
         [1, 1, 1, 1, 1],
         [1, 0, 0, 1, 0]]

def max(a)
    max = 0
    1.upto(a.size - 1).each { |i|
        1.upto(a[0].size - 1).each { |j|
            a[i][j] = [a[i - 1][j], a[i][j - 1], a[i - 1][j - 1]].min + 1 unless a[i][j] == 0
            max = [a[i][j], max].max
        }
    }

    max ** 2
end

puts max(board)
board.each { |x|
    puts x.inspect
}
