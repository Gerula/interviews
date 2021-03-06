class Array
    def merge_discrete
        min = self.flatten.min
        max = self.flatten.max
        bits = Array(min..max).map { |x| 0 }
        self.each { |x|
            x[0].upto(x[1]).each { |i|
                bits[i] = 1
            }
        }

        result = []
        start = nil
        0.upto(bits.size).each { |x|
            if x == 0 || bits[x - 1] == 0 && bits[x] == 1
                start = min + x - 1
            end
            if x > 0 && bits[x - 1] == 1 && bits[x] == 0 || x == max
                finish = min + x - (x == max ? 1 : 2)
                result << [start, finish]
            end
        }

        result
    end

    def merge
        intervals = self.sort { |x| x[0] <=> x[1] }
        result = [intervals[0]]
        for i in 1..intervals.size - 1
            if result[-1][1] > intervals[i][0]
                result[-1][1] = intervals[i][1]
            else
                result << intervals[i]
            end
        end 

        result
    end
end

puts [[1,3],[2,6],[8,10],[15,18]].merge_discrete.inspect
puts [[1,3],[2,6],[8,10],[15,18]].merge.inspect
