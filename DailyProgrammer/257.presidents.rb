#   https://www.reddit.com/r/dailyprogrammer/comments/49aatn/20160307_challenge_257_easy_in_what_year_were/

require 'csv'
require 'date'

def overlaps?(a, b)
    b[3].between?(a[1], a[3]) ||
    a[3].between?(b[1], b[3])
end

intervals = CSV.read("257.in").drop(1).map { |x|
    [[x[0]], x[1].split(" ").last.strip.to_i, x[2], x[3].strip.empty? ? Date.today.year : x[3].split(" ").last.strip.to_i]
}

puts "#{intervals.map { |x| x[1] }.min.upto(intervals.map { |x| x[1] }.max).map { |x|
    [x, intervals.select { |y| x.between?(y[1], y[3]) }.map { |y| y[0] }]
}
.group_by { |x| x[1].size }
.max
.last}"

