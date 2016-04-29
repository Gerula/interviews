class Array
    def powerset
        [[]] + (0...self.size).map { |x| self[x + 1..-1].powerset.map { |y| [self[x]] + y }}.flatten(1)
    end
end
