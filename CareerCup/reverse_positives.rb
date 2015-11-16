# Given an array reverse the order of the positive elements
#

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def reverse_positives!
        prev = 0
        for i in 0..self.size
            if i == self.size || self[i] < 0
                self.reverse!(prev, i - 1)
                prev = i + 1
            end
        end

        return self
    end

    def reverse!(low, high)
        while low < high
            self[low], self[high] = self[high], self[low]
            low += 1
            high -= 1
        end

        return self
    end
end

assert_equal(
    [9, 8, 3, 4, -2, 13, 10, 6, -1, 3, 2],
    [4, 3, 8, 9, -2, 6, 10, 13, -1, 2, 3].reverse_positives!)
