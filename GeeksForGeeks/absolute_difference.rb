require 'test/unit'
extend Test::Unit::Assertions

class Array
    def search(value)
        i = 0
        while i < self.size
            if self[i] == value
                return i
            end

            i += (self[i] - value).abs
        end

        return -1
    end
end

assert_equal(7, [8, 7, 6, 7, 6, 5, 4, 3, 2, 3, 4, 3].search(3))
assert_equal(5, [0, 1, 0, 1, 2, 3, 4, 3, 2, 3, 4, 3].search(3))
assert_equal(-1, [0, 1, 0, 1, 2, 3, 4, 3, 2, 3, 4, 3].search(10))
