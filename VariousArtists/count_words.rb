# Actually got this one once. So you have a matrix. Count the number of times you find a specified word in it snake-wise
#

def count_recursive(word_array, grid, line, column)
    return 0 if !line.between?(0, grid.length - 1) || !column.between?(0, grid[0].length - 1) ||
                !word_array.any? ||
                word_array.first != grid[line][column]
    return 1 if word_array.length == 1
    return count_recursive(word_array[1..-1], grid, line - 1, column - 1) +
           count_recursive(word_array[1..-1], grid, line - 1, column) +
           count_recursive(word_array[1..-1], grid, line - 1, column + 1) +
           count_recursive(word_array[1..-1], grid, line, column - 1) +
           count_recursive(word_array[1..-1], grid, line, column + 1) +
           count_recursive(word_array[1..-1], grid, line + 1, column - 1) +
           count_recursive(word_array[1..-1], grid, line + 1, column)
end

def count(word, grid)
    count = 0
    word_array = word.split("")
    (0..grid.length - 1).each { |line|
        (0..grid[0].length - 1).each { |column|
            count += count_recursive(word_array, grid, line, column)
        }
    }

    return count
end

grid = [['c', 'a', 't', 'a', 't'],
        ['a', 't', 'b', 'c', 'a'],
        ['a', 't', 'b', 'c', 'a'],
        ['a', 't', 'b', 'c', 'a'],
        ['a', 't', 'b', 'c', 'a']]

puts count("c", grid)
