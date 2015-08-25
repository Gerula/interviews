# https://leetcode.com/submissions/detail/37492731/
#
# HAHAHAHAHAHA!!! 
#
# You are here!
# Your runtime beats 100.00% of ruby coders.
#
# 22 / 22 test cases passed.
#   Status: Accepted
#   Runtime: 72 ms
#       
#       Submitted: 0 minutes ago
#

def spiral_order(matrix)
    offsets = [[ 0,  1], # right first
               [ 1,  0], # down second
               [ 0, -1], # left third
               [-1,  0]  # up forth
              ].cycle
    
    result = []
    return result if matrix.nil? || matrix.size == 0
    start = [0, 0]
    offset = offsets.next
    (matrix.size * matrix[0].size).times {
        result << matrix[start.first][start.last]
        matrix[start.first][start.last] = nil
        next_start = [start.first + offset.first, start.last + offset.last]
        offset = offsets.next if !next_start.first.between?(0, matrix.size - 1) ||
                                 !next_start.last.between?(0, matrix[0].size - 1) ||
                                 matrix[next_start.first][next_start.last] == nil
        start = [start.first + offset.first, start.last + offset.last]
    }

    return result
end

puts spiral_order([
                   [ 1, 2, 3 ],
                   [ 4, 5, 6 ],
                   [ 7, 8, 9 ]
                  ]).inspect

puts spiral_order([
                   [ 1, 2, 3, 4 ],
                   [12,13,14, 5 ],
                   [11,16,15, 6 ],
                   [10, 9, 8, 7 ]
                  ]).inspect

puts spiral_order([
                   [ 1, 2, 3, 4 ]
                  ]).inspect
