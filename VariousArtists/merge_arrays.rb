require "test/unit"
extend Test::Unit::Assertions

class Array
    def merge(other)
        new_size = self.size + other.size - 1
        first = self.size - 1
        second = other.size - 1
        while new_size >= 0
            if first >= 0 && second >= 0
                if self[first] > other[second]
                    self[new_size] = self[first]
                    first -= 1
                else
                    self[new_size] = other[second]
                    second -= 1
                end
            elsif first >= 0
                self[new_size] = self[first]
                first -= 1
            else
                self[new_size] = other[second]
                second -= 1
            end
            new_size -= 1
        end

        return self
    end
end

assert_equal([1, 2, 3, 4, 5, 6, 7, 8], [1, 3, 5, 7, 8].merge([2, 4, 6]))
assert_equal([1, 3, 4, 5, 6, 8, 10, 11, 12, 14, 15, 19], [3, 4, 6, 10, 11, 15].merge([1, 5, 8, 12, 14, 19]))
