# min
#

class Array
    def max_2
        self.reduce { |acc, x|
            acc = [acc, x].max
        }
    end
end

puts [1, 2, 3, 4, 5, 6, 7, 8].max_2
