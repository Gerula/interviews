class Array
    def max_surpasser
        self.map.with_index { |x, i|
            self[i..-1].nil? ? 0 : self[i..-1].count { |y| y > x }
        }.max
    end
end

puts [2, 7, 5, 5, 2, 7, 0, 8, 1].max_surpasser
