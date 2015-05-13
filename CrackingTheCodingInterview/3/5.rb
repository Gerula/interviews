#  Implement a MyQueue class which implements a queue using two stacks.
#

class Stack
    def initialize
        @array = []
    end

    def push(element)
        @array.push(element)
    end

    def pop
        @array.pop
    end

    def peek
        @array[-1]
    end
end

class MyQueue
    def initialize
        @stack1 = Stack.new
        @stack2 = Stack.new
    end

    def enqueue(element)
        @stack2.push(element)
    end

    def dequeue
        while @stack2.peek
            @stack1.push(@stack2.pop)
        end

        value = @stack1.pop

        while @stack1.peek
            @stack2.push(@stack1.pop)
        end

        return value
    end
end

queue = MyQueue.new
queue.enqueue(1)
puts queue.inspect
puts queue.dequeue
queue.enqueue(1)
puts queue.inspect
queue.enqueue(2)
puts queue.inspect
queue.enqueue(3)
puts queue.inspect
puts queue.dequeue
puts queue.inspect
puts queue.dequeue
puts queue.inspect
