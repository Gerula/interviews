class Array
    def max_sum
        mins = self[-1]

        (self.size - 2).downto(0).each{ |i|
            0.upto(self[i].size - 1).each { |j|
                mins[j] = self[i][j] + [mins[j], mins[j + 1]].min
            }
        }

        mins[0]
    end
end

puts [   [2],
        [3, 4],
       [6, 5, 7],
       [4, 1, 8, 3]
].max_sum
