# Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
#
# You may assume that the intervals were initially sorted according to their start times.
#

class Array
    def add_interval(interval)
        (interval[0]..interval[1]).each { |i|
            self[i] = 1
        }
    end

    def merge_interval!(interval)
        current_intervals = []

        self.each{ |x|
            current_intervals.add_interval(x)
        }

        current_intervals.add_interval(interval)

        start_interval = nil
        end_interval = nil
        
        self.clear

        1.upto(current_intervals.size - 1).each { |i|
            if current_intervals[i] == 1 && (i == 0 || current_intervals[i - 1] != 1)
                start_interval = i
            elsif current_intervals[i] != 1 && current_intervals[i - 1] == 1
                end_interval = i
                self << [start_interval, end_interval - 1]
                start_interval = nil
            end
        }

        if !start_interval.nil?
            self << [start_interval, current_intervals.size - 1]
        end

        self
    end
end

puts [[1,3],[6,9]].merge_interval!([2, 5]).inspect
puts [[1,2],[3,5],[6,7],[8,10],[12,16]].merge_interval!([4, 9]).inspect
