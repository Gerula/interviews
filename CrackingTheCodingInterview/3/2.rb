#  How would you design a stack which, in addition to push and pop, also has a function min which returns the minimum element? Push, pop and min should all operate in O(1) time.
#

class Stack_min
    require 'ostruct'

    def initialize
        @array = []
    end

    def pop
        top = @array[-1]
        if !top
            puts "Stack is empty"
            return nil
        end

        @array.pop
        top.value
    end

    def push(value)
        top = @array[-1]
        new_value = OpenStruct.new(:value => value, :min => value)
        if top && value > top.min
            new_value.min = top.min
        end

        @array.push(new_value)    
    end

    def min
        top = @array[-1]
        if !top
            puts "Stack is empty"
            return nil
        end

        top.min
    end
end

stack = Stack_min.new
stack.push(1)
puts stack.min
stack.push(2)
puts stack.min
stack.push(3)
puts stack.min
stack.push(0)
puts stack.min
stack.pop
puts stack.min
