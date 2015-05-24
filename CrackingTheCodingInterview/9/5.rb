#  Given a sorted array of strings which is interspersed with empty strings, write a meth- od to find the location of a given string.
#

class Array
    def find_str(str)
        left = 0
        right = self.size - 1

        while left < right
            mid = left + (right - left) / 2
            while self[right] == ""
                right -= 1
            end

            while self[mid] == ""
                mid += 1
            end

            if self[mid] == str
                return mid
            end

            if self[mid] < str
                left = mid + 1
            else
                right = mid - 1
            end
        end

        return -1
    end
end

puts ["at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""].find_str("ball")
puts ["at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""].find_str("ballcar")
puts ["at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""].find_str("dad")
