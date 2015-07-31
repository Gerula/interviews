# Design a queue which supports N operations of Enqueue, Dequeue and Max to have a O(N) complexity - cummulated

class Deque
    def initialize
        @data = []
    end

    def enqueue(value)
        while @data.any? && self.tail < value
            @data.pop
        end

        @data.push(value)
    end

    def dequeue(value)
        @data.shift if self.head == value
    end
    
    def head
        return @data.first
    end

    def tail
        return @data.last
    end
end

class Queue
    def initialize
        @data = []
    end

    def enqueue(value)
        @data.push(value)
    end

    def dequeue
        return @data.any? ? @data.shift : nil
    end

    def empty?
        return @data.empty?
    end
end

class MaxQueue
    def initialize
        @queue = Queue.new
        @deque = Deque.new
    end

    def enqueue(value)
        @queue.enqueue(value)
        @deque.enqueue(value)
    end

    def dequeue
        unless @queue.empty?
            value = @queue.dequeue
            @deque.dequeue(value)
        end
    end

    def max
        return @deque.head
    end
end

require 'test/unit'
extend Test::Unit::Assertions

queue = MaxQueue.new

queue.enqueue(1)
assert_equal(1, queue.max)
1.upto(10).each { |x| queue.enqueue(x) }
queue.enqueue(1)
11.times {
    assert_equal(10, queue.max)
    queue.dequeue
}

assert_equal(1, queue.max)
