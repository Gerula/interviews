class Array
    def max_battery
        min = 10000
        capacity = 0
        for val in self
            capacity = [capacity, val - min].max
            min = [min, val].min
        end

        capacity
    end
end

puts [4, 2, 5, 7, 1, 1, 2, 4].max_battery
