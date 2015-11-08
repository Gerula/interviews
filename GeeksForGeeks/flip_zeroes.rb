# http://www.geeksforgeeks.org/find-zeroes-to-be-flipped-so-that-number-of-consecutive-1s-is-maximized/
#
# Given a binary array and an integer m, find the position of zeroes flipping which creates maximum number of consecutive 1s in array.
#

class Array
    def flip(n)
        left = self.map { |x| 0 }
        right = self.map { |x| 0 }
        zeroes = []
        leftOnes = 0
        rightOnes = 0
        for i in 0...self.size
            j = self.size - i - 1
            left[i] = leftOnes
            right[i] = rightOnes
            if self[i] == 1
                leftOnes += 1
            else
                zeroes.push(i)
                leftOnes = 0
            end
            if self[j] == 1
                rightOnes += 1
            else
                rightOnes = 0
            end
        end

        return zeroes.each_cons([n, zeroes.length].min).map { |x|
            [x.inject(0){  |acc, i|
                      acc + left[i] + right[i]}, x]
        }.
        sort{|a, b| a.first <=> b.first}.
        last.last
    end

    def flip_2(n)
        num_zeroes = 0
        left = 0
        length = 0
        start = 0
        right = 0
        while right < self.length
            if num_zeroes <= n
                num_zeroes += 1 if self[right] == 0
                right += 1
            end

            if num_zeroes > n
                num_zeroes -= 1 if self[left] == 0
                left += 1
            end

            if right - left > length
                start = left
                length = right - left
            end
        end
        
        return self[start, length].each_with_index.inject([]) { |acc, x|
            acc.push(x.last + start) if x.first == 0
            acc
        }
    end
end

[[[1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1], 2],
 [[1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1], 1],
 [[0, 0, 0, 1], 4]].each { |x|
    puts "#{x.first} #{x.first.flip(x.last)}"
    puts "#{x.first} #{x.first.flip_2(x.last)}"
}
