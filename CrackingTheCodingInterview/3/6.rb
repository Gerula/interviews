#  Write a program to sort a stack in ascending order. You should not make any assump- tions about how the stack is implemented. The following are the only functions that should be used to write this program: push | pop | peek | isEmpty.
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

    def is_empty?
        @array.length == 0
    end

    def sort
        s = Stack.new
        while !is_empty?
            value = pop
            while !s.is_empty? && s.peek > value
                push(s.pop)
            end
            s.push(value)
        end

        return s
    end
end

stack = Stack.new
puts "Stack empty? #{stack.is_empty?}"
stack.push(2)
puts "Stack empty? #{stack.is_empty?}"
puts "Stack peek #{stack.peek}"
puts "Stack pop #{stack.pop}"
puts "Stack empty? #{stack.is_empty?}"
stack.push(3)
stack.push(0)
stack.push(10)
stack.push(1)
puts stack.inspect
stack = stack.sort
puts stack.inspect
