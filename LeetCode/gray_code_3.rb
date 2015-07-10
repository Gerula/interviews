class Fixnum
    def gray_code
        result = [0]
        self.times {
            size = result.size
            (size - 1).downto(0).each { |j|
                result << result[j] + size
            }
        }

        result
    end
end

puts 3.gray_code.inspect
