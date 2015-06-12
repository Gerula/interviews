# Given a sorted array of integers, find the starting and ending position of a given target value.
#
# Your algorithm's runtime complexity must be in the order of O(log n).
#
# If the target is not found in the array, return [-1, -1].
#
# For example,
# Given [5, 7, 7, 8, 8, 10] and target value 8,
# return [3, 4]. 
#

class Array 
    def search(value)
        first = bsearch(value, :left, 0, self.size)
        return [-1, -1] if first == -1
        return [first, bsearch(value, :right, first, self.size)]
    end

    def bsearch(value, direction, left, right)
        position = -1
        while left < right
            mid = left + (right - left) / 2
            if self[mid] == value
                position = mid
                case direction 
                when :left then right = mid - 1
                when :right then left = mid + 1
                end
            elsif self[mid] > value
                right = mid - 1
            else
                left = mid + 1
            end
        end

        return position
    end
end

puts [5, 7, 7, 8, 8, 10].search(8).inspect
puts [5, 7, 7, 8, 8, 10].search(100).inspect
