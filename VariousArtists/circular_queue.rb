require 'test/unit'
extend Test::Unit::Assertions

class CQueue
    def initialize(size)
        @start = @end = 0
        @array = Array.new(size)
    end

    def enqueue(value)
        next_end = (@end + 1) % @array.size
        if next_end == @start
            return false
        end

        @end = next_end
        @array[@end] = value
        return true
    end

    def dequeue
        if @start == @end
            return nil
        end

        result = @array[@start]
        @start = (@start + 1) % @array.size 
    end
end

queue = CQueue.new(4)
assert_equal(nil, queue.dequeue)
assert_equal(true, queue.enqueue(1))
assert_equal(true, queue.enqueue(2))
assert_equal(true, queue.enqueue(3))
assert_equal(false, queue.enqueue(3))
assert_equal(1, queue.dequeue)
assert_equal(2, queue.dequeue)
assert_equal(3, queue.dequeue)
