# Reverse a null terminated string
#

class Array
    def reverse_n!
        low = 0
        high = self.length - 2
        while low < high
            self[low], self[high] = self[high], self[low]
            low += 1
            high -= 1
        end

        self
    end

    def reverse_2
        result = self.inject([]) {|acc, x|
            if x != nil
                acc.unshift(x)
            end
            acc
        }
        result << nil
        result
    end
end

[[1, 2, 3, nil],
 [1, 2, 3, 4, nil],
 [1,nil],
 [nil]].each { |x|
    puts x.reverse_2.inspect
}

