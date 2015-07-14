class Array
    def oddx
        return self.reduce(:^)
    end

    def odd
        low = 0
        high = self.size
        while low <= high
            if low == high
                return self[low]
            end

            mid = low + (high - low) / 2
            if mid % 2 == 0
                if self[mid] == self[mid + 1]
                    low = mid + 2
                else
                    high = mid
                end
            else
                if self[mid] == self[mid - 1]
                    low = mid + 1
                else
                    high = mid - 1
                end
            end
        end

        return -1
    end
end

[[5, 2, 1, 2, 1, 3, 2, 3, 2],
 [4, 4, 4, 4, 3, 3, 3, 3, 3],
 [1, 1, 1, 2, 2, 3, 3]].each { |x|
    puts "#{x.inspect} #{x.oddx} #{x.odd}"
}
