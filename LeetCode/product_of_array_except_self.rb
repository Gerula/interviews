class Array
    def product
        left = 1
        0.upto(self.size - 1).each { |i|
            left *= self[i]
        }

        right = 1
        output = []

        (self.size - 1).downto(0).each { |i|
            left /= self[i]
            output[i] = right * left
            right *= self[i]
        }

        output
    end
end

puts [1,2,3,4].product.inspect
