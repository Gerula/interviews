# Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
#
# Note: You can only move either down or right at any point in time.
#

n = Random.rand(5..10)
m = Random.rand(5..10)
grid = []
line = []
(m*n).times {
    line << Random.rand(1..n*m)
    if line.size == m
        grid << line
        line = []
    end
}

grid.each {|x|
    puts x.inspect
}
 
class Array
    def min_path
        start = [0, 0]
        sum = 0
        while start != [self.size - 1, self[0].size - 1]
            sum += self[start[0]][start[1]]
            if start[0] + 1 > self.size - 1
                start[1] += 1
                next
            end
            if start[1] + 1 > self[0].size - 1
                start[0] += 1
                next
            end
            if self[start[0] + 1][ start[1]] > self[start[0]][start[1] + 1]
                start[1] += 1
            else
                start[0] += 1
            end
        end 
        sum
    end
end

puts grid.min_path
