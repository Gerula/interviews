class Array
    def merge_sort
        return sort(self)
    end

    def sort(array)
        return array if array.length <= 1
        mid = array.length / 2
        left = sort(array[0...mid])
        right = sort(array[mid..-1])
        merge(left, right)
    end

    def merge(first, second)
        result = []
        while first.any? && second.any?
            result.push(first[0] < second[0] ? first.shift : second.shift)
        end

        result + first + second
    end
end


puts Array(1..Random.rand(10..20)).map { |x| Random.rand(1..20)}.merge_sort.inspect
