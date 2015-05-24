#  Given a sorted array of n integers that has been rotated an unknown number of times, give an O(log n) algorithm that finds an element in the array. You may assume that the array was originally sorted in increasing order.
#  EXAMPLE:
#  Input: find 5 in array (15 16 19 20 25 1 3 4 5 7 10 14)
#  Output: 8 (the index of 5 in the array)
#

class Array
    def rotate!(positions)
        positions.times {
            self.push(self.shift)
        }   
    end

    def divide_et_impera(value)
        left = 0
        right = self.length - 1
        
        while left <= right
            mid = left + (right - left) / 2
            if self[mid] == value
                return mid
            end

            if self[left] <= self[mid]
                if value.between?(self[left], self[mid])
                    right = mid - 1
                else
                    left = mid + 1
                end
            else
                if value.between?(self[mid], self[right])
                    left = mid + 1
                else
                    right = mid - 1
                end
            end
        end

        return -1
    end

    def get_pivot
        left = 0
        right = self.length - 1
        while left <= right
            mid = left + (right - left) / 2
            if self[mid] > self[mid + 1]
                return mid
            end

            if self[mid] > self[right]
                left = mid + 1
            else
                right = mid - 1
            end
        end

        return -1
    end
end

a = Array(1..30)
a.rotate!(10)
puts a.inspect
puts a.divide_et_impera(5)
puts a.divide_et_impera(20)
puts a.divide_et_impera(11)
puts a.divide_et_impera(10)

puts "Pivot #{a.get_pivot}"
