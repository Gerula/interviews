class Array
    def power
        results = []
        powerbar([], results, 0)
        return results
    end

    def powerbar(result, results, step)
        results << result.dup
        step.upto(self.size - 1).each { |i|
            next if (i > step) && self[i] == self[i - 1] 
            result.push(self[i])
            powerbar(result, results, i + 1)
            result.pop
        }
    end
end

puts [1, 2, 2, 2].power.inspect

