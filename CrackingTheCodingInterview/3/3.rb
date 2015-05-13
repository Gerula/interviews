# Imagine a (literal) stack of plates. If the stack gets too high, it might topple. There- fore, in real life, we would likely start a new stack when the previous stack exceeds some threshold. Implement a data structure SetOfStacks that mimics this. SetOf- Stacks should be composed of several stacks, and should create a new stack once the previous one exceeds capacity. SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack (that is, pop() should return the same values as it would if there were just a single stack).
#

class Stacks
    def initialize(number, size)
        @arrays = []
        number.times {
            @arrays.push(Array.new(size))
        }

        @size = size
        @max_elements = number
        @current = 0
    end

    def pop
        unless @current == 0
            value = @array[@current / @size][@current % @size]
            @current -= 1
            return value
        end

        puts "Stack is empty"
        return nil
    end

    def push(element)
        unless @current == @size * @max_elements - 1
            @arrays[@current / @size][@current % @size] = element
            @current += 1
            return
        end

        puts "Stack is full"
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
