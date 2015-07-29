class Array
    def riffle
        mid = self.size / 2
        result = []
        left = self[0...mid]
        right = self[mid..-1]
       
        while result.size < self.size
            unless left.empty?
                left_index = Random.rand(0..left.size)
                result += left[0, left_index]
                left = left[left_index..-1] ||= []
            end
            unless right.empty?
                right_index = Random.rand(0..right.size)
                result += right[0, right_index]
                right = right[right_index..-1] ||= []
            end
        end

        return result
    end

    def riffle?(original)
        k, i, j = 0, 0, original.size / 2
        return false if original.size != self.size

        while k < original.size
            flag = false
            while original[i] == self[k] && i < original.size / 2
                i += 1
                k += 1
                flag = true
            end

            while original[j] == self[k] && j < original.size
                j += 1
                k += 1
                flag = true
            end

            return false if !flag
        end

        return true
    end
end

array = Array(1..30)
puts array.inspect
riffle = array.riffle
puts riffle.inspect
puts riffle.riffle?(array)
riffle = riffle.riffle
puts riffle.inspect
puts riffle.riffle?(array)
