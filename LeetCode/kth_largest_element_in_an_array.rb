# quickselect
#
#

class Array
    def qs(n)
        left = 0
        right = self.size - 1
        while left < right
            read = left
            write = right
            mid = self[read + (write - read) / 2]

            while read < write
                if self[read] >= mid
                    self[read], self[write] = self[write], self[read]
                    write -= 1
                else
                    read += 1
                end
            end

            if self[read] > mid
                read -= 1
            end

            if n <= read
                right = read
            else
                left = read + 1
            end
        end

        puts self.inspect
        return self[n]
    end
end

5.times {
   input = []
   Random.rand(5..15).times {
        input << Random.rand(1..30)
   }
   
   k = Random.rand(1..input.size) 
   puts "#{input.inspect} - #{input.qs(3)} - #{3}"
}

