class Array
    def find_insert(number)
        low = 0
        high = self.size
        while low < high
            mid = low + (high - low) / 2
            if self[mid] == number
                return mid
            end

            if self[mid] > number
                high = mid
            else
                low = mid + 1
            end
        end

        return low
    end
end

[[[1,3,5,6], 5, 2],
 [[1,3,5,6], 2 ,1],
 [[1,3,5,6], 7 ,4],
 [[1,3,5,6], 0 ,0]].each { |x|
    puts "#{x[0].inspect} #{x[0].find_insert(x[1])} #{x[2]}"
}
