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

    def riffle?
        true
    end
end

array = Array(1..30)
puts array.inspect
riffle = array.riffle
puts riffle.inspect
puts riffle.riffle?
