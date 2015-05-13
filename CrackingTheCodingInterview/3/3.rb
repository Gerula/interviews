# Imagine a (literal) stack of plates. If the stack gets too high, it might topple. There- fore, in real life, we would likely start a new stack when the previous stack exceeds some threshold. Implement a data structure SetOfStacks that mimics this. SetOf- Stacks should be composed of several stacks, and should create a new stack once the previous one exceeds capacity. SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack (that is, pop() should return the same values as it would if there were just a single stack).
#

class Stack
    def initialize(size)
        @array = []
        @max_size = size
    end

    def push(element)
        unless @array.size == @max_size
            @array.push(element)
            return element
        end
        
        return nil
    end

    def pop
        @array.pop
    end
end

class Stacks
    def initialize(number, size)
        @stacks = []
        number.times {
            @stacks.push(Stack.new(size))
        }

        @size = size
        @max_elements = number
        @current = 0
    end

    def pop
        index = @max_elements - 1
        value = nil
        while !value && index > 0
            value = @stacks[index].pop
            index -= 1
        end

        return value
    end

    def push(element)
        index = 0
        while !@stacks[index].push(element)
            index += 1
        end
    end

    def inspect
        @stacks.each { |x| puts x.inspect }
    end
end

stacks = Stacks.new(3, 2)
puts stacks.inspect
stacks.push(1)
stacks.push(2)
stacks.push(1)
stacks.push(1)
stacks.push(1)
puts stacks.inspect
stacks.pop
stacks.pop
puts stacks.inspect
stacks.push("shit")
stacks.push("futurama")
stacks.push(Stacks.new(0, 0))
puts stacks.inspect
