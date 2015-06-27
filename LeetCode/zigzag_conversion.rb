class String
    def zigzag(rows)
        zig = Array.new(rows).map {
                    Array.new(self.size).map {
                        " "
                    }
             }
        row = 0
        column = 0
        up = true
        self.chars.each { |c|
            zig[row][column] = c
            if row == 0
                up = true
            end

            if (row == rows - 1)
                up = false
            end

            if up 
                row += 1
            else
                row -= 1
                column += 1
            end
        }

        zig.map { |x| x.select{ |y| y != " "}.join("") }.join("")
    end
end

puts "PAYPALISHIRING".zigzag(3)
