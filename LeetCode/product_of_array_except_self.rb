class Array
    def product
        left = 1
        output = []
        0.upto(self.size - 1).each { |i|
            output[i] = left
            left *= self[i]
        }

        right = 1

        (self.size - 1).downto(0).each { |i|
            output[i] = right * output[i]
            right *= self[i]
        }

        output
    end
end

puts [1,2,3,4].product.inspect
