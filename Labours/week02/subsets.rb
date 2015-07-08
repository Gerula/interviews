class Array
    def powerset
        result = []
        0.upto(2 ** self.size - 1).each { |mask|
            set = []
            0.upto(self.size - 1).each { |i|
                if ((1 << i) & mask) != 0
                    set << self[i]
                end
            }

            result << set
        }

        return result
    end
end

puts [1, 2, 3].powerset.inspect

