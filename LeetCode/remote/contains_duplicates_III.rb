# Given an array of integers, find out whether there are two distinct indices i and j in the array such that the difference between nums[i] and nums[j] is at most t and the difference between i and j is at most k. 
#

require 'test/unit'
extend Test::Unit::Assertions

class Deque
    def initialize(flag)
        @data = []
        @flag = flag
        @size = 0
    end

    def compare(x, y)
        @flag ? [x, y].max : [x, y].min
    end

    def enqueue(value)
        while @data.any? && compare(@data.last, value) == value
            @data.pop
        end

        @size += 1
        @data.push(value)
    end

    def dequeue(value)
        @size -= 1
        @data.shift if @data.first == value
    end

    def head
        return @data.first
    end

    def size
        return @size
    end
end

def contains_nearby_almost_duplicate(nums, k, t)
    dequeue_max = Deque.new(true)
    dequeue_min = Deque.new(false)
    return false if k == 0
    nums.each_with_index { |x, i|
        dequeue_max.dequeue(nums[i - k]) if dequeue_max.size > k
        dequeue_min.dequeue(nums[i - k]) if dequeue_min.size > k

        puts dequeue_max.inspect
        puts dequeue_min.inspect

        return true if !dequeue_max.head.nil? && dequeue_max.head - x <= t || 
                       !dequeue_min.head.nil? && x - dequeue_min.head <= t
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

