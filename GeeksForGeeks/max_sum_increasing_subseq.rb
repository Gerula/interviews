class Array
    def max_sum_sub
        subseq = self.dup
        sub = subseq.map { |x| [x] }
        1.upto(self.size - 1).each do |i|
            0.upto(i - 1).each do |j|
                if self[i] > self[j] && subseq[i] < subseq[j] + self[i]
                    subseq[i] = subseq[j] + self[i]
                    sub[i] += sub[j]
                    sub[i] = sub[i].uniq
                end
            end
        end
        
        puts sub.detect{ |x| x.reduce(:+) == subseq.max }.inspect
        return subseq.max
    end
end

puts [1, 101, 2, 3, 100, 4, 5].max_sum_sub
