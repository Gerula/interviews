class Array 
    def rotate!
        for idx in 0..0
            for i in idx..self.size - 1 - idx
                puts "#{self[idx][i]} #{self[i][self.size - 1 - idx]} #{self[self.size - 1 - idx][self.size - 1 - i]} #{self[self.size - 1 - i][idx]}"
                aux = self[idx][i]
                self[idx][i] = self[self.size - 1 - i][idx]
                self[self.size - 1 - i][idx] = self[self.size - 1 - idx][self.size - 1 - i]
                self[self.size - 1 - idx][self.size - 1 - i] = self[i][self.size - 1 - idx]
                self[i][self.size - 1 - idx] = aux
            end
        end

        #  [idx][i]    [idx][size - i - i]
        #
        #
        #  [size - idx - 1][i]  [size - idx - 1][size - i - 1]
        #

        return self
    end

    def to_s
        self.inject("") { |acc,x| acc + "[" + x.join(", ") + "]\n" }
    end
end

start = 0
a = Array.new(5).map { |x|
        Array.new(5).map { |y|
            start += 1
        }
    }

puts a.to_s
puts
puts a.rotate!.to_s
