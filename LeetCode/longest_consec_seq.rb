a = [100, 4, 200, 1, 3, 2]

class Array
    def lcs
        hash = {}
        self.each { |x|
            high = x
            low = x
            if hash[x - 1]
                low = hash[x - 1]
                hash.delete(x - 1)
            end
            if hash[x + 1]
                high = hash[x + 1]
                hash.delete(x + 1)
            end

            hash[high] = low
            hash[low] = high
        }

        max = 0
        max_interval = []
        hash.each{ |low, high|
            if high - low > max
                max_interval = [low, high]
            end
        }

        return Array(max_interval.first..max_interval.last)
    end
end

puts a.lcs.inspect

