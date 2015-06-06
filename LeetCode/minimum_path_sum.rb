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
        (1..self.size-1).each do |i|
            self[i][0] = self[i-1][0] + self[i][0]
        end
        (1..self[0].size-1).each do |j|
            self[0][j] = self[0][j-1] + self[0][j]
        end

        (1..self.size-1).each do |i|
            (1..self[0].size-1).each do |j|
                self[i][j] = [self[i-1][j] + self[i][j], self[i][j-1] + self[i][j]].min
            end
        end

        self[self.size - 1][self[0].size - 1]
    end
end

puts grid.min_path
