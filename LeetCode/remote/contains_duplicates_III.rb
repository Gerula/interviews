# Given an array of integers, find out whether there are two distinct indices i and j in the array such that the difference between nums[i] and nums[j] is at most t and the difference between i and j is at most k. 
#

require 'test/unit'
extend Test::Unit::Assertions

class Deque
    def initialize(flag)
        @data = []
        @flag = flag
    end

    def compare(x, y)
        @flag ? [x, y].max : [x, y].min
    end

    def enqueue(value)
        count = 0
        while @data.any? && compare(@data.last[0], value) == value
            count += @data.last[1] + 1
            @data.pop
        end

        @data.push([value, count])
    end

    def dequeue
        if @data.first[1] > 0
            @data.first[1] -= 1
        end

        @data.shift 
    end

    def head
        return @data.first[0] unless @data.first.nil?
    end
end

def contains_nearby_almost_duplicate(nums, k, t)
    dequeue_max = Deque.new(true)
    dequeue_min = Deque.new(false)
    return false if k == 0
    nums.each_with_index { |x, i|
        dequeue_max.dequeue if i > k
        dequeue_min.dequeue if i > k 
        puts dequeue_min.inspect
        puts dequeue_max.inspect
        return true if !dequeue_max.head.nil? && dequeue_max.head == x ||
                       !dequeue_min.head.nil? && dequeue_min.head == x
        return true if !dequeue_max.head.nil? && x < dequeue_max.head && dequeue_max.head - x <= t || 
                       !dequeue_min.head.nil? && x > dequeue_min.head && x - dequeue_min.head <= t
        dequeue_max.enqueue(x)
        dequeue_min.enqueue(x)
    }

    return false
end

assert_equal(true, contains_nearby_almost_duplicate([1, 2, 3, 4, 5], 2, 2))
assert_equal(true, contains_nearby_almost_duplicate([-1, -1], 1, 0))
assert_equal(false, contains_nearby_almost_duplicate([1, 2], 0, 1))
assert_equal(true, contains_nearby_almost_duplicate([2, 1], 1, 1))
assert_equal(false, contains_nearby_almost_duplicate([1, 3, 1], 1, 1))
assert_equal(true, contains_nearby_almost_duplicate([7, 1, 3], 2, 3))
assert_equal(true, contains_nearby_almost_duplicate([3, 6, 0, 2], 2, 2))

