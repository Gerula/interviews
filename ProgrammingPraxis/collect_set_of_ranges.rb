require 'test/unit'
extend Test::Unit::Assertions

class Array
    def to_intervals
        result = []
        interval_start = nil
        for i in 0...self.size 
            interval_start ||= self[i]
            if i == self.size - 1 || self[i] + 1 != self[i + 1]
                result.push(interval_start != self[i] ? [interval_start, self[i]] : [self[i]])
                interval_start = nil
            end
        end

        return result
    end
end

assert_equal([[1, 4], [7, 8], [10], [12, 16]],[1, 2, 3, 4, 7, 8, 10, 12, 13, 14, 15, 16].to_intervals)
assert_equal([[0, 2], [7], [21, 22], [108, 109]], [0, 1, 2, 7, 21, 22, 108, 109].to_intervals)

