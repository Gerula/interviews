require 'test/unit'
extend Test::Unit::Assertions

class Array
    def inflection
        right = self.reduce(:+)
        min = self.max
        left = 0
        min_index = -1
        for i in 0...self.size
            left += self[i]
            right -= self[i]
            diff = (left - right).abs
            if diff < min
                min = diff
                min_index = i
            end
        end

        return self[min_index]
    end
end

assert_equal(9, [3, 7, 9, 8, 2, 5, 6].inflection)
