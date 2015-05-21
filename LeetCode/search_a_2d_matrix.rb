# Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
#
#    Integers in each row are sorted from left to right.
#    The first integer of each row is greater than the last integer of the previous row.
#
# For example,
#
# Consider the following matrix:
# 
# [
#   [1,   3,  5,  7],
#   [10, 11, 16, 20],
#   [23, 30, 34, 50]
# ]
# 
# Given target = 3, return true.

size = 8
a = []
(0..size-1).each {|current|
    a[current] ||= []
    (0..current).each {|line|
       a[line] ||= []
       a[line][current] = current
       a[current][line] = current + 1 
    }
}

puts a.map {|row| row.inspect<<" \n" }

def search(a, value)
    line = 0
    column = a.size - 1
    while line.between?(0,a.size-1) && column.between?(0,a.size-1)
        if a[line][column] < value
            line += 1
        elsif a[line][column] > value
            column -= 1
        else
            return true
        end
    end
    return false
end

puts [0, 2, 6, 100, 11, 9, 10].map{|x| "#{x} - #{search(a, x)}"}.join("\n")
