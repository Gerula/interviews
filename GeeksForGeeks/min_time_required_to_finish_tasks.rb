#   http://www.geeksforgeeks.org/minimum-time-to-finish-tasks-without-skipping-two-consecutive/
#   Given time taken by n tasks.
#   Find the minimum time needed to finish the tasks such that skipping of tasks is allowed, but can not skip two consecutive tasks.

require 'test/unit'
extend Test::Unit::Assertions

class Array
    def min_time
        dont_complete = 0
        complete = 0
        self.each { |x|
            skip = complete
            complete = [dont_complete, complete].min + x
            dont_complete = skip
        }

        [complete, dont_complete].min
    end
end

assert_equal(12, [10, 5, 7, 10].min_time)
assert_equal(0, [10].min_time)
assert_equal(10, [10, 30].min_time)
assert_equal(22, [10, 5, 2, 4, 8, 6, 7, 10].min_time)
