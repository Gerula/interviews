# Find sum of all elements in a matrix except the elements in row and/or column of given cell?
#

def sum_matrix(matrix, array)
    lines = matrix.map { |x| x.reduce(:+) }
    columns = 0.upto(matrix.first.size - 1).map { |j| 
                0.upto(matrix.size - 1).inject(0) { |acc, i|
                    acc + matrix[i][j]
                }
              }
    
    total = lines.reduce(:+)
    array.map { |x|
        total - lines[x[0]] - columns[x[1]] + matrix[x[0]][x[1]]
    }
end

puts sum_matrix([[1, 1, 2],
                 [3, 4, 6],
                 [5, 3, 2]],  
                [[0, 0], 
                 [1, 1], 
                 [0, 1]])
