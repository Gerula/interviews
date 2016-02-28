#   https://leetcode.com/problems/merge-intervals/
#
#   Given a collection of intervals, merge all overlapping intervals.
#
#   For example,
#   Given [1,3],[2,6],[8,10],[15,18],
#   return [1,6],[8,10],[15,18]. 
#   https://leetcode.com/submissions/detail/54758053/
#
#   Submission Details
#   168 / 168 test cases passed.
#       Status: Accepted
#       Runtime: 204 ms
#           
#           Submitted: 0 minutes ago

def merge(intervals)
    intervals
    .sort { |x, y| x.start <=> y.start }
    .reduce([]) { |acc, x|
        if acc.empty?
            acc << x
        elsif acc.last.end.between?(x.start, x.end) ||
              x.end.between?(acc.last.start, acc.last.end)    
            acc[-1] = Interval.new([acc[-1].start, x.start].min,
                                   [acc[-1].end, x.end].max)
        else
            acc << x
        end
        
        acc
    }
end

