#   https://leetcode.com/problems/insert-interval/
#   Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).
#
#   You may assume that the intervals were initially sorted according to their start times.
#   https://leetcode.com/submissions/detail/54348173/
#   Submission Details
#   151 / 151 test cases passed.
#       Status: Accepted
#       Runtime: 132 ms
#           
#           Submitted: 0 minutes ago

def overlaps(first, second)
    return first.start.between?(second.start, second.end) ||
           first.end.between?(second.start, second.end) ||
           second.start.between?(first.start, first.end) ||
           second.end.between?(first.start, first.end)
end

def merge(first, second)
    Interval.new([first.start, second.start].min, [first.end, second.end].min)
end

def insert(intervals, new_interval)
    intervals << new_interval
    intervals.select { |x| x.end < new_interval.start } +
    [intervals.select { |x| overlaps(x, new_interval) }
             .inject(Interval.new(2 ** (0.size * 8), -(2 ** (0.size * 8)))) { |acc, x|
                Interval.new([acc.start, x.start].min, [acc.end, x.end].max)
             }] +
    intervals.select { |x| x.start > new_interval.end }
end

#   Evolution in a nutshell
#   
#   Submission Details
#   151 / 151 test cases passed.
#       Status: Accepted
#       Runtime: 144 ms
#           
#           Submitted: 0 minutes ago
#   https://leetcode.com/submissions/detail/56512286/
def insert(intervals, new_interval)
    intervals << new_interval
    intervals.select { |x| x.end < new_interval.start } +
    [intervals.select { |x| overlaps?(x, new_interval) }.reduce { |acc, x|
        Interval.new([acc.start, x.start].min, [acc.end, x.end].max)
    }] +
    intervals.select { |x| new_interval.end < x.start}
end

def overlaps?(first, second)
    first.start.between?(second.start, second.end) ||
    first.end.between?(second.start, second.end) ||
    second.start.between?(first.start, first.end) ||
    second.end.between?(first.start, first.end) 
end
