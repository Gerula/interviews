class Array
    def find_min
        low = 0
        high = self.size - 1
        while low < high
            if low == high - 1
                return [self[low], self[high]].min
            end

            if self[low] < self[high]
                return self[low]
            end

            mid = low + (high - low) / 2

            if self[low] > self[mid]
                high = mid
            else
                low = mid
            end
        end
    end
end

puts [4, 5, 6, 7, 0, 1, 2].find_min
