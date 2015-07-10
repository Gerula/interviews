class Array
    def max_sum
        max_local = self[0]
        max_total = self[0]
        for i in 1..self.size - 1
           max_local = [max_local + self[i], self[i]].max
           max_total = [max_local, max_total].max
        end

        max_total
    end
end

puts [-2, 1, -3, 4, -1, 2, 1, -5, 4].max_sum
