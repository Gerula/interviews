# Count the mines problem.

class Array
    def mines
        result = Array.new(self.size) {
            Array.new(self[0].size) {
                0
            }
        }

        for i in 0...self.size
            for j in 0...self[i].size
                count = 0
                [0, i - 1].max.upto([self.size - 1, i + 1].min).each { |k|
                    [0, j - 1].max.upto([self[i].size - 1, j + 1].min).each { |l|
                        count += 1 if self[k][l] != 0
                    }
                }

                result[i][j] = count
            end
        end

        return result
    end

    def to_s
        result = ""
        self.each { |x|
            result += "#{x.inspect}\n"
        }

        result
    end
end

puts [[0, 1, 0, 1],
      [0, 0, 0, 1],
      [0, 1, 0, 1],
      [1, 0, 0, 1]].
      mines.
      to_s


