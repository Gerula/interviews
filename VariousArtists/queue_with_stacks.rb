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
        Queue::evacuate(@storage, @maneuver)
        result = @maneuver.pop
        Queue::evacuate(@maneuver, @storage)
        return result
    end

    class << self
        def evacuate(source, target)
            while source.any?
                target.push(source.pop)
            end
        end
    end
end

queue = Queue.new
1.upto(10).each { |x| queue.enqueue(x) }
1.upto(10).each { |x|
    assert_equal(x, queue.dequeue)
}

assert_equal(nil, queue.dequeue)
