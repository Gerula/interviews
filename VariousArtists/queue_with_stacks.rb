# implement a queue with two stacks
#

require 'test/unit'
extend Test::Unit::Assertions

class Queue
    def initialize
        @storage = []
        @maneuver = []
    end

    def enqueue(value)
        @storage.push(value)
    end

    def dequeue
        return nil if @storage.empty?
        while @storage.any?
            @maneuver.push(@storage.pop)
        end

        result = @maneuver.pop
        while @maneuver.any?
            @storage.push(@maneuver.pop)
        end

        return result
    end
end

queue = Queue.new
1.upto(10).each { |x| queue.enqueue(x) }
1.upto(10).each { |x|
    assert_equal(x, queue.dequeue)
}

assert_equal(nil, queue.dequeue)
