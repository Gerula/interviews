class Fixnum
    def combinations(result, k, step)
        if result.size == k
            puts result.inspect
        end

        step.upto(self).each { |i|
            self.combinations(result + [i], k, i + 1)
        }
    end
end

4.combinations([], 2, 1)

