class String
    def zigzag(rows)
        zig = Array.new(rows).map {
                    Array.new(self.size).map {
                        " "
                    }
             }
        row = 0
        column = 0
        up = false
        self.chars.each { |c|
            zig[row][column] = c
            if row == 0 || row == rows - 1
                up = !up
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

    def zigggy(rows) 
    end
end

puts "PAYPALISHIRING".zigzag(3)
puts "PAYPALISHIRING".zigggy(3)
puts "AB".zigzag(1)
puts "AB".zigzag(1)
