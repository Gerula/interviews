# The median of an array is the value in the middle if the array was sorted;
# if the array has an odd number of items n, the median is the (n+1)/2'th largest item in the array
# (which is also the (n+1)/2'th smallest item in the array), and if the array has an even number of items n,
# the median is the arithmetic average of the n/2'th smallest item in the array and the n/2'th largest item in the array.
# For instance, the median of the array [2,4,5,7,3,6,1] is 4 and the median of the array [5,2,1,6,3,4] is 3.5.

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def median
        half = self.size / 2

        self.size % 2 == 1 ? 
            self.select(half) :
           (self.select(half - 1) + self.select(half)).to_f / 2
    end

    def select(index)
        low = 0
        high = self.size - 1
        while low < high
            pivot = self[Random.rand(low..high)]
            read, write = low, high
            while read < write
                if self[read] >= pivot
                    self[read], self[write] = self[write], self[read]
                    write -= 1
                else
                    read += 1
                end
            end

            read -= 1 if self[read] > pivot

            if read >= index
                high = read
            else
                low = read + 1
            end
        end

        return self[index]
    end
end

assert_equal(4, [2, 4, 5, 7, 3, 6, 1].median)
assert_equal(3.5, [5, 2, 1, 6, 3, 4].median)
puts "All tests passed. Who's the man?"


