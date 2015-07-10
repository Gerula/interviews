class Array
    def merge_with!(other)
        write_point = self.size + other.size - 1
        first = self.size - 1
        second = other.size - 1
        while first >= 0 && second >= 0
            if self[first] > other[second]
                self[write_point] = self[first]
                first -= 1
            else
                self[write_point] = other[second]
                second -= 1
            end
            write_point -= 1
        end

        while first >= 0
            self[write_point] = self[first]
            first -= 1
            write_point -= 1
        end
        while second >= 0
            self[write_point] = other[second]
            second -= 1
            write_point -= 1
        end

        self
    end
end

puts [1, 4, 5, 8].merge_with!([1, 2, 3, 4, 5, 6, 7, 8]).inspect
