# Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
#
# You may assume no duplicates in the array.
#
# Here are few examples.
# [1,3,5,6], 5 → 2
# [1,3,5,6], 2 → 1
# [1,3,5,6], 7 → 4
# [1,3,5,6], 0 → 0 
#

class Array
    def target(x)
        left = 0
        right = self.size
        while left < right
            mid = left + (right - left) / 2
            if self[mid] == x
                return mid
            end
            if self[mid] > x
                right = mid - 1
            else
                left = mid + 1
            end
        end
        return left
    end
end

[[[1, 3, 5, 6], 5],
 [[1, 3, 5, 6], 2],
 [[1, 3, 5, 6], 7],
 [[1, 3, 5, 6], 0]].each { |x|
    puts "#{x[0].inspect} - #{x[1]} = #{x[0].target(x[1])}"
}
