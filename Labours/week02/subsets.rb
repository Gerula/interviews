class Array
    def powerset
        result = []
        0.upto(2 ** self.size - 1).each { |mask|
            set = []
            0.upto(self.size - 1).each { |i|
                if ((1 << i) & mask) != 0
                    set << self[i]
                end
            }

            result << set
        }

        return result
    end

    def power
        results = []
        powerbar([], results, 0)
        return results
    end

    def powerbar(result, results, step)
        results << result.dup
        step.upto(self.size - 1).each { |i|
            result.push(self[i])
            powerbar(result, results, i + 1)
            result.pop
        }
    end
end

puts [1, 2, 3].powerset.inspect
puts [1, 2, 3].power.inspect

