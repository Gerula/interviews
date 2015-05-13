# Describe how you could use a single array to implement three stacks.
# A: I wouldn't
#

class Stack
    def initialize(array, offset, size)
        @data_layer = array
        @start_offset = offset
        @max_size = size
        @current_position = @start_offset - 1
    end

    def push(element)
        if @current_position == @start_offset + @max_size - 1
            puts "Stack is full"
            return
        end
        
        @current_position += 1
        @data_layer[@current_position] = element
    end

    def pop
        if @current_position == @start_offset - 1
            puts "Stack is empty"
            return
        end
        
        @current_position -= 1
        return @data_layer[@current_position + 1]
    end
end

class Three_Stacks
    def initialize(max_size)
        while max_size % 3 != 0
            max_size -= 1
        end

        @data_layer = Array.new(max_size)
        stack_size = max_size / 3

        @stacks = [Stack.new(@data_layer, 0, stack_size),
                   Stack.new(@data_layer, stack_size, stack_size),
                   Stack.new(@data_layer, stack_size *2, stack_size)] 
    end

    def push(stack, element)
        @stacks[stack].push(element)
    end

    def pop(stack)
        @stacks[stack].pop
    end

    def inspect
        @stacks.each {|x| puts x.inspect }
    end
end

stacks = Three_Stacks.new(10)
puts stacks.inspect
stacks.push(0, 1)
stacks.push(0, 2)
stacks.push(0, 3)
stacks.push(1, 4)
stacks.push(1, 5)
stacks.push(1, 6)
stacks.push(2, 7)
stacks.push(2, 8)
stacks.push(2, 9)
puts stacks.inspect
stacks.push(1, 10)
stacks.push(1, 2)
puts stacks.inspect
puts stacks.pop(0)
puts stacks.pop(0)
stacks.push(0, 100)
puts stacks.inspect
